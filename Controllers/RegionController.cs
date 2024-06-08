using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NzApp.CustomActionFilters;
using NzApp.Data;
using NzApp.Model.Domain;
using NzApp.Model.Dtos;
using NzApp.Repository;
using System.Text.Json;


namespace NzApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public RegionController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
       /* [Authorize(Roles = "Reader")]*/
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("Get all action method was invoked");
            logger.LogWarning("This is a warning log");
            logger.LogError("This is a error log");


            //Get Data From Database -Domain Model
            var regionsDomain = await regionRepository.GetAllAsync();

            //Return Dtos
            logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
            

            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        /*[Authorize(Roles = "Reader")]*/
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetById(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        [ValidateModel]
        /*[Authorize(Roles = "Writer")]*/
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)

        {
          

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
          
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        /*[Authorize(Roles = "Writer")]*/
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
         
            
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDto>(regionDomainModel));
          
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        /*[Authorize(Roles = "Writer, Reader")]*/
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }





}
