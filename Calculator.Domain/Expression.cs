using System.Text;

namespace Calculator.Domain
{
    public class Expression
    {
        public string InputExpression { get; set; }
        public List<double> Values { get; set; }
        public List<char> Operators { get; set; }

        public Expression(string input)
        {
            InputExpression = input;
            SetValues();
            SetOperators();
        }

        private void SetValues()
        {
            char[] input_chars = InputExpression.ToCharArray();
            Values = new List<double>();

            for (int i = 0; i < input_chars.Length; i++)
            {
                if (char.IsDigit(input_chars[i]))
                {
                    StringBuilder sbuf = new StringBuilder();
                    while (i < input_chars.Length && char.IsDigit(input_chars[i]))
                    {
                        sbuf.Append(input_chars[i++]);
                    }
                    Values.Add(int.Parse(sbuf.ToString()));
                    i--;
                }
            }
        }

        public void SetOperators()
        {
            Operators = new List<char>();
            char[] input_chars = InputExpression.ToCharArray();
            for (int i = 0; i < input_chars.Length - 1; i++)
            {
                if (input_chars[i] == '+')
                    Operators.Add('+');
                else if (input_chars[i] == '-')
                    Operators.Add('-');
                else if (input_chars[i] == '*')
                    Operators.Add('*');
                else if (input_chars[i] == '/')
                    Operators.Add('/');
            }
        }
    }
}