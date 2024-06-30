using System.Xml.Serialization;

namespace E_Belge.Model.Classes;

public class ArrayOfGibAccount
{
  [XmlElement(ElementName = "GibAccount")]
  public List<GibAccount> GibAccount;
}

public class GibAccount
{
  public int Id;
  public string GibAccountName;
  public int GibAccountType;
  public string EInvoiceStartDate;
  //   [XmlElement(ElementName = "EWaybillStartDate")]
  //   public string EWaybillStartDate;
  public int GibAccountUsageType;
  public int GibUserType;
  public string IdentifierNo;
  //   public string LastUpdateDate;
  public string IsPassive;
}

public class ArrayOfGibAccountAlias
{
  [XmlElement(ElementName = "GibAccountAlias")]
  public List<GibAccountAlias> GibAccountAlias;
}

public class GibAccountAlias
{
  public int Id;
  public int GibAccountId;
  public string Alias;
  public DateTime AliasCreateDate;
  public int GibDocumentType;
  [XmlElement(ElementName = "AliasDeleteDate")]
  public string AliasDeleteDate;
  public int AliasType;
}