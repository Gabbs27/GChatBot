using GChatBot.Data.Constants;
using GChatBot.Services.ChatServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GChatBot.Tests;

[TestClass]
public class BotCommandServiceTests
{
    private readonly BotCommandService _service;
    public string ValidCommand { get; private set; } = string.Empty;

    public BotCommandServiceTests()
    {
        _service = new BotCommandService();
    }

    [TestInitialize]
    public void SetUp()
    {
        ValidCommand = BotCommands.StockCommand;
    }

    [TestMethod]
    public void Given_ValidCommand_Return_CorrectCommandInfo()
    {
        var result = _service.GetCommandInformation($"{ValidCommand}=GOOG");
        Assert.AreEqual(ValidCommand, result.Command);
        Assert.AreEqual("GOOG", result.Parameter);
        Assert.IsNull(result.Error);
    }

    [TestMethod]
    public void Given_InvalidCommand_Return_CommandNotFoundError()
    {
        var result = _service.GetCommandInformation("/invalidCommand=param");
        Assert.IsTrue(result.Error?.Contains("Command not found"));
    }

    [TestMethod]
    public void Given_CommandWithoutEqualsSign_Return_InvalidParameterError()
    {
        var result = _service.GetCommandInformation(ValidCommand);
        Assert.AreEqual(BotConstants.Errors.InvalidParameter, result.Error);
    }

    [TestMethod]
    public void Given_ValidCommand_Return_NoValidationError()
    {
        var result = _service.ValidateCommand($"{ValidCommand}=GOOG");
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Given_CommandWithoutStartSlash_Return_InvalidCommandFormatError()
    {
        var result = _service.ValidateCommand("stock=GOOG");
        Assert.AreEqual(BotConstants.Errors.InvalidCommandFormat, result);
    }

    [TestMethod]
    public void Given_CommandStartingWithSlash_Return_IsCommandTrue()
    {
        var result = _service.IsCommand($"{ValidCommand}=GOOG");
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Given_CommandNotStartingWithSlash_Return_IsCommandFalse()
    {
        var result = _service.IsCommand("stock=GOOG");
        Assert.IsFalse(result);
    }
}