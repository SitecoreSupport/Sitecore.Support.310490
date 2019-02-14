using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.WFFM.Abstractions.Actions;
using Sitecore.WFFM.Actions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support
{
  public class ValidateFormIntegrity : WffmCheckAction
  {
    public override void Execute(ID formid, IEnumerable<ControlResult> fields, ActionCallContext actionCallContext = null)
    {
      try
      {
        foreach (var field in actionCallContext.FormItem.Fields)
        {
          var ok = fields.First(f => ID.Parse(f.FieldID) == field.ID);
        }
      }
      catch (InvalidOperationException e)
      {
        Log.Warn(string.Format("Posted field collection does not match the form {0} definition.",formid), e, this);
        throw;
      }
    }
  }
}