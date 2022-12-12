using Ardalis.Specification;
using Core.Entities;

namespace Core.ProjectAggregate.Specifications
{
    public class TodoByIdWithItemsSpec : Specification<Todo>, ISingleResultSpecification
    {
        public TodoByIdWithItemsSpec(int todoId)
        {
            Query
                .Where(todo => todo.Id == todoId);
        }
    }
}
