using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzApp.CustomActionFilters;
using NzApp.Model.Domain;
using NzApp.Model.Dtos;
using NzApp.Repository;
using System.Net;

namespace NzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            //map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomainModel);
            //Mapp Domain Model to walkDto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string?  sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            

                var walkDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, 
                    isAscending ?? true, pageNumber, pageSize);

                throw new Exception("This is a new exception");

                //Map DomainModel to Dto
                return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
            

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map Dto to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateRegionRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }







        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Walk>(deletedWalkDomainModel));
        }

    }
}


