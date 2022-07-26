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

        private void SetValues() // bayad tamiz beshe
        {
            char[] input_chars = InputExpression.ToCharArray();
            Values = new List<double>();

            if (input_chars.Length == 1)
            {
                if (char.IsDigit(input_chars[0]))
                {
                    Values.Add(int.Parse(input_chars[0].ToString()));
                }
            }

            for (int i = 0; i < input_chars.Length - 1; i++)
            {
                if (input_chars[i] >= '0' && input_chars[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();
                    while (i < input_chars.Length && input_chars[i] >= '0' && input_chars[i] <= '9')
                    {
                        sbuf.Append(input_chars[i++]);
                    }
                    Values.Add(int.Parse(sbuf.ToString()));
                    i--;
                }
                else if (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/')
                {
                    if (Char.IsDigit(input_chars[i + 1]))
                    {
                        if (i + 1 == input_chars.Length - 1)
                        {
                            Values.Add(Char.GetNumericValue(input_chars[i + 1]));
                        }
                    }
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