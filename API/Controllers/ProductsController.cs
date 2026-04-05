using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController(IGenericRepository<Product> _repository) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductSpecificationParameters specificationParameters)
    {
        var specification = new ProductSpecification(specificationParameters);
        return await CreatePagedResult(_repository, specification,
            specificationParameters.PageIndex, specificationParameters.PageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _repository.Add(product);
        if (await _repository.SaveAllAsync())
        {
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        return BadRequest("Unable to create the product!");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (product.Id != id || !ProductExists(id))
            return BadRequest("Unable to update this product!");

        _repository.Update(product);
        if (await _repository.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Unable to update this product!");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();
        _repository.Remove(product);
        if (await _repository.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Unable to delete the product!");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var specification = new BrandListSpecification();
        return Ok(await _repository.ListAsync(specification));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var specification = new TypeListSpecification();
        return Ok(await _repository.ListAsync(specification));
    }

    private bool ProductExists(int id)
    {
        return _repository.Exists(id);
    }
}
