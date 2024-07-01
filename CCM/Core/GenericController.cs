using Microsoft.AspNetCore.Mvc;

namespace CCM.Core
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity>(IGenericService<TEntity> service) : ControllerBase
        where TEntity : class
    {
        [HttpPost(GenericRoute.List)]
        public async Task<ActionResult<IEnumerable<TEntity>>> ListAllAsync([FromBody] DataFilter filter)
        {
            var entities = await service.ListAllAsync(filter);
            return Ok(entities);
        }

        [HttpPost(GenericRoute.Count)]
        public async Task<ActionResult<int>> CountAllAsync([FromBody] DataFilter filter)
        {
            var count = await service.CountAllAsync(filter);
            return Ok(count);
        }

        [HttpPost(GenericRoute.GetById)]
        public async Task<ActionResult<TEntity>> GetById(ulong id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost(GenericRoute.Create)]
        public async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            var createdEntity = await service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(createdEntity) }, createdEntity);
        }

        [HttpPost(GenericRoute.Update)]
        public async Task<ActionResult<TEntity>> Update(ulong id, TEntity entity)
        {
            if (id != GetEntityId(entity))
            {
                return BadRequest();
            }

            var updatedEntity = await service.UpdateAsync(entity);
            return Ok(updatedEntity);
        }

        [HttpPost(GenericRoute.Delete)]
        public async Task<ActionResult<bool>> Delete(ulong id)
        {
            var result = await service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private ulong? GetEntityId(TEntity entity)
        {
            var propertyInfo = entity.GetType().GetProperty("Id");

            if (propertyInfo == null)
            {
                return null;
            }

            return (ulong?)propertyInfo.GetValue(entity);
        }
    }
}