using AutoMapper;

using ETM.API.Core.Entities;
using ETM.API.Core.Exceptions;
using ETM.API.Core.Models;
using ETM.API.Models.DTOs.Comment;
using ETM.API.Models.DTOs.Ticket;
using ETM.API.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System.Linq.Expressions;

namespace ETM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketService ticketService, ICommentService commentService, IMapper mapper, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _commentService = commentService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> FindAllTicketsAsync([FromQuery] QueryParameters parameters)
        {
            var filterConditionList = new List<Expression<Func<Ticket, bool>>>();

            try
            {
                if (parameters.UserIds != null && parameters.UserIds.Any())
                {
                    Expression<Func<Ticket, bool>> filterWithUserCondition = t => parameters.UserIds.Contains(t.CreatedBy);
                    filterConditionList.Add(filterWithUserCondition);
                }

                if (parameters.DepartmentIds != null && parameters.DepartmentIds.Any())
                {
                    Expression<Func<Ticket, bool>> filterWithDepartmentCondition = t => parameters.DepartmentIds.Contains(t.DepartmentId);
                    filterConditionList.Add(filterWithDepartmentCondition);
                }

                if (parameters.StatusIds != null && parameters.StatusIds.Any())
                {
                    Expression<Func<Ticket, bool>> filterWithStatusCondition = t => parameters.StatusIds.Contains(t.StatusId);
                    filterConditionList.Add(filterWithStatusCondition);
                }

                if (parameters.StartDateTime != DateTime.MinValue.Date && parameters.EndDateTime != DateTime.MinValue.Date)
                {
                    Expression<Func<Ticket, bool>> filterWithDateCondition = t => t.CreatedOn.Date >= parameters.StartDateTime.Date &&
                                                                                  t.CreatedOn.Date <= parameters.EndDateTime.Date;

                    filterConditionList.Add(filterWithDateCondition);
                }

                Expression<Func<Ticket, DateTime>> sortCondition = t => t.CreatedOn;

                var ticketList = await _ticketService.GetTicketsByFilterAsync(
                    filterConditionList,
                    parameters.PageNumber,
                    parameters.PageSize,
                    parameters.IsAscendingOrder,
                    parameters.IsAllowSorting ? sortCondition : null);

                if (ticketList == null)
                    return NotFound();

                return Ok(ticketList);

            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : FindAllTicketsAsync(QueryParameters parameters) method. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketAsync([FromBody] TicketAddDTO ticketDto)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDto);
                bool success = await _ticketService.AddTicketAsync(ticket);

                return Ok(success);
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : AddTicketAsync(TicketAddDTO ticketDto) method. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> DeleteTicketByIdAsync(int ticketId)
        {
            try
            {
                bool success = await _ticketService.DeleteTicketAsync(ticketId);
                return Ok(success);
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : DeleteTicketByIdAsync(int ticketId) method with ticketId = {ticketId}. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{ticketId}")]
        public async Task<IActionResult> UpdateTicketAsync(int ticketId, TicketUpdateDTO ticketUpdateDto)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketUpdateDto);
                bool success = await _ticketService.UpdateTicketAsync(ticketId, ticket);

                return Ok(success);
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : UpdateTicketAsync(int ticketId, TicketUpdateDTO ticketUpdateDto) method with ticketId = {ticketId}. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{ticketId}/Comment")]
        public async Task<IActionResult> AddCommentForTicketAsync(int ticketId, [FromBody] CommentAddDTO commentDto)
        {
            try
            {
                var ticket = await _ticketService.GetSingleTicketByIdAsync(ticketId);

                if (ticket != null)
                {
                    var comment = _mapper.Map<Comment>(commentDto);
                    bool success = await _commentService.AddCommentAsync(comment);

                    return Ok(success);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : AddCommentForTicketAsync method. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{ticketId}/Comment/{commentId}")]
        public async Task<IActionResult> DeleteCommenForTicketAsync(int ticketId, int commentId)
        {
            try
            {
                Expression<Func<Comment, bool>> condition = c => (c.TicketId == ticketId && c.Id == commentId);
                bool success = await _commentService.DeleteCommentAsync(condition);
                return Ok(success);
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : DeleteCommenForTicketAsync method. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{ticketId}/Comment/{commentId}")]
        public async Task<IActionResult> UpdateCommentForTicketAsync(int ticketId, int commentId, CommentUpdateDTO commentUpdateDto)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentUpdateDto);
                Expression<Func<Comment, bool>> condition = c => c.TicketId == ticketId && c.Id == commentId;

                bool success = await _commentService.UpdateCommentAsync(condition, comment);

                return Ok(success);
            }
            catch (ETMException ex)
            {
                _logger.LogError($"{ex.Message}, Error : {ex.InnerException.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in TicketController : UpdateCommentForTicketAsync method with ticketId = {ticketId}. Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
