using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandRecognition
{
    public static class ApplicationSettings
    {
        public static int InputNodes = 784;
        public static int HiddenNodes = 100;
        public static int OutputNodes = 10;
        public static float LearningRate = 0.3f;
    }
}
