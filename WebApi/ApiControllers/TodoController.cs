using Core.Entities;
using Core.ProjectAggregate.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedCore.Enums;
using SharedCore.Interfaces;
using WebApi.ApiModels;


namespace WebApi.ApiControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<Todo> _repository;

        public TodoController(IRepository<Todo> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var todoDTOs = (await _repository.ListAsync())
                .Select(todo => new TodoDTO
                (
                    id: todo.Id,
                    title: todo.Title,
                    text: todo.Text,
                    status: (TodoStatusEnum)todo.Status,
                    createdDate: todo.CreatedDate,
                    deactivationDate: todo.DeactivationDate
                ))
                .ToList();

            return Ok(todoDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoDTO request)
        {
            var newTodo = new Todo(request?.Title, request?.Text);

            var createdTodo = await _repository.AddAsync(newTodo);

            var result = new TodoDTO
            (
                id: createdTodo.Id,
                title: createdTodo.Title,
                text: createdTodo.Text,
                status: (TodoStatusEnum)createdTodo.Status,
                createdDate: createdTodo.CreatedDate,
                deactivationDate: createdTodo.DeactivationDate
            );

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoSpec = new TodoByIdWithItemsSpec(id);
            var todo = await _repository.FirstOrDefaultAsync(todoSpec);

            if (todo == null)
                return NotFound();

            var result = new TodoDTO
            (
                id: todo.Id,
                title: todo.Title,
                text: todo.Text,
                status: (TodoStatusEnum)todo.Status,
                createdDate: todo.CreatedDate,
                deactivationDate: todo.DeactivationDate
            );

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var todoSpec = new TodoByIdWithItemsSpec(id);
            var todo = await _repository.FirstOrDefaultAsync(todoSpec);

            if (todo == null)
                return NotFound();

            await _repository.DeleteAsync(todo);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateTodoDTO newModel)
        {
            var todoSpec = new TodoByIdWithItemsSpec(id!);
            var todo = await _repository.FirstOrDefaultAsync(todoSpec);

            if (todo == null)
                return NotFound();

            todo.Title = newModel.Title;
            todo.Text = newModel.Text;

           await _repository.UpdateAsync(todo);

            var result = new TodoDTO
            (
                id: todo.Id,
                title: todo.Title,
                text: todo.Text,
                status: (TodoStatusEnum)todo.Status,
                createdDate: todo.CreatedDate,
                deactivationDate: todo.DeactivationDate
            );

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var todoSpec = new TodoByIdWithItemsSpec(id!);
            var todo = await _repository.FirstOrDefaultAsync(todoSpec);

            if (todo == null)
                return NotFound();

            todo.DeactivationDate = DateTime.UtcNow;
            todo.Status = (int)TodoStatusEnum.InActive;

            await _repository.UpdateAsync(todo);

            return Ok();
        }
    }
}
