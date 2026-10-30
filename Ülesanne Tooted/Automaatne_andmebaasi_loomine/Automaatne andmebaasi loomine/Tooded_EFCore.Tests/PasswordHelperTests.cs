namespace Tooded_EFCore.Tests;

public class PasswordHelperTests
{
    [Fact]
    public void Hash_Parool_EiSalvestaParooliEnnast()
    {
        string rasi = PasswordHelper.Hash("salajane");

        Assert.NotEqual("salajane", rasi);
        Assert.DoesNotContain("salajane", rasi);
    }

    [Fact]
    public void Verify_OigeParool_TagastabTrue()
    {
        string rasi = PasswordHelper.Hash("salajane");

        Assert.True(PasswordHelper.Verify("salajane", rasi));
    }

    [Fact]
    public void Verify_ValeParool_TagastabFalse()
    {
        string rasi = PasswordHelper.Hash("salajane");

        Assert.False(PasswordHelper.Verify("Salajane", rasi));   // suur S
    }

    [Fact]
    public void Hash_SamaParoolKahesti_AnnabErinevadRasid()
    {
        string rasi1 = PasswordHelper.Hash("salajane");
        string rasi2 = PasswordHelper.Hash("salajane");

        // BCrypt lisab igale räsile juhusliku "soola"
        Assert.NotEqual(rasi1, rasi2);
    }
}
