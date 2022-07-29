/*
 * Personal Finance Management API
 *
 * Personal Finance Management API allows analyze of a client's spending patterns against pre-defined budgets over time 
 *
 * OpenAPI spec version: v1
 * Contact: aleksandar.milosevic@asseco-see.rs
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Example.Attributes;
using Example.Models;
using CsvHelper;
using System.Globalization;
using Example.Mapping;
using Example.Repositories;

namespace Example.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoriesApiController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }


        [HttpGet]
        [Route("/v1/pfm/categories")]
        [ValidateModelState]

        public virtual async Task<IActionResult> CategoriesGetList([FromQuery] string? parentId)
        {
            var list = _CategoryRepository.GetAll().Result;
            List<Category> lista=new List<Category>();
            if (String.IsNullOrEmpty(parentId))
            {
                foreach (var l in list)
                {
                    if (String.IsNullOrEmpty(l.ParentCode))
                        lista.Add(l);
                }
                return Ok(lista);
            }
            else
            {
                foreach (var l in list)
                {
                    if (l.ParentCode == parentId)
                        lista.Add(l);
                }
            }
            return Ok(lista);

        }
        [HttpPost]
        [Route("/v1/pfm/categories/import")]
        [ValidateModelState]

        public virtual async Task<IActionResult> Categoryimport(IFormFile file)
        {
            try
            {
                var fileextension = Path.GetExtension(file.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                }
                if (fileextension == ".csv")
                {
                    using (var reader = new StreamReader(filepath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<CategoryMap>();
                        var records = csv.GetRecords<Category>();
                        foreach (var record in records)
                        {

                            if (await _CategoryRepository.Get(record.Code) != null)
                            {
                                await _CategoryRepository.Delete(record.Code);

                                await _CategoryRepository.Add(record);
                            }
                            else
                                await _CategoryRepository.Add(record);

                            }
                            return Ok();
                        }

                    } 
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
