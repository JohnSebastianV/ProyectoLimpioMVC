using ProyectoDeAula3.Controllers;
using ProyectoDeAula3.Models;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using System.Web.Mvc;

public class IdeasDeNegocioControllerTests
{
    [Fact]
    public void Index_ReturnsViewResult_WithListOfIdeasDeNegocio()
    {
        // Arrange
        var controller = new IdeasDeNegocioController();
        var ideasDeNegocio = new List<IdeaDeNegocio>
        

        // Act
        var result = controller.Index(ideasDeNegocio);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<IdeaDeNegocio>>(viewResult.ViewData.Model);
        Assert.Equals(ideasDeNegocio, model);
    }

    [Fact]
    public void Crear_ReturnsViewResult()
    {
        // Arrange
        var controller = new IdeasDeNegocioController();

        // Act
        var result = controller.Crear();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void CrearPost_WithValidModel_ReturnsRedirectToActionResult()
    {
        // Arrange
        var controller = new IdeasDeNegocioController();
        var idea = new IdeaDeNegocio
        

        // Act
        var result = controller.Crear(idea);

        // Assert
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Detalles_ReturnsViewResult_WithIdeaDeNegocio()
    {
        // Arrange
        var controller = new IdeasDeNegocioController();
        var idea = new IdeaDeNegocio
       

        // Act
        var result = controller.Detalles(idea.Codigo);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IdeaDeNegocio>(viewResult.ViewData.Model);
        Assert.Equal(idea, model);
    }
}


