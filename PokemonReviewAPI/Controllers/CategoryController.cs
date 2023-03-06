﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.Dto;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]

        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
                return NotFound();
            
            var category = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);    
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var pokemons = _mapper.Map<List <PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokemons);
        }
    }
}