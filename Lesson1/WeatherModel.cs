namespace Lesson1
{
    public class WeatherModel
    {

        public enum CloudCoverEnum { Cloudy, MostlyCloudy, PartlyCloudy, MostlySunny, Sunny }

        public enum PrecipitationEnum { None, Rain, Snow, Hail }

        private DateTime _Date;

        private int _TempC;

        private int _TempF;

        private uint _Wind;

        private uint _UVIndex;

        private CloudCoverEnum _CloudCover;

        private PrecipitationEnum _Precipitation;

        public int TempC { get { return _TempC;  } set { _TempC = value; } }

        public int TempF { get { return _TempF;  } set { _TempF = value; } }

        public uint Wind { get { return _Wind; } }

        public uint UVIndex { get { return _UVIndex; } }

        public string CloudCover { get { return _CloudCover.ToString(); } }

        public string Precipitation { get { return _Precipitation.ToString(); } }

        public string Date { get { return _Date.ToShortDateString(); } }

        



        public WeatherModel(DateTime date, uint wind, uint uvIndex, uint cloudcover, uint precipitation, int temp)
        {
            _Date = date;

            _Wind = wind;

            _UVIndex = uvIndex;

            _CloudCover = (CloudCoverEnum)cloudcover;

            _Precipitation = (PrecipitationEnum)precipitation;

            TempC = temp;

            TempF = (int)((TempC * 1.8) + 32);
        }
    }
}
