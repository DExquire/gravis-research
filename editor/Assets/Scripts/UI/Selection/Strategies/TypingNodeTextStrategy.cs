﻿using System.Threading.Tasks;

namespace UI.Selection.Strategies
{
    public class TypingNodeTextStrategy : NodeTextStrategyBase
    {
        public override async Task<string> GetText()
        {
            var inputField = NodeInputField.Instance;
            return await inputField.TypeText();
        }
    }
}