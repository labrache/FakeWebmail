namespace FWMBuilder
{
    internal class ArgumentParser
    {
        private static List<String> parameterArguments = new List<string> { "-in", "-out" };
        private Dictionary<String, String> parameters = new Dictionary<string, string>();

        public ArgumentParser(String[] inputParams)
        {
            for (int i = 0; i < inputParams.Length; i++)
            {
                if (parameterArguments.Contains(inputParams[i]))
                {
                    if (i < inputParams.Length - 1)
                    {
                        parameters.Add(inputParams[i].Remove(0, 1), inputParams[i + 1]);
                        i++;
                    }
                }
            }
        }
        public Boolean getIn(out String inFile)
        {
            if (parameters.ContainsKey("in"))
            {
                inFile = parameters["in"];
                return true;
            }
            inFile = null;
            return false;
        }
        public Boolean getOut(out String outFile)
        {
            if (parameters.ContainsKey("out"))
            {
                outFile = parameters["out"];
                return true;
            }
            outFile = null;
            return false;
        }

    }
}
