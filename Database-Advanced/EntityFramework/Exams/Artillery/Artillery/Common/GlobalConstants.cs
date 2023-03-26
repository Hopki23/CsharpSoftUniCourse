namespace Artillery.Common
{
    public class GlobalConstants
    {
        //Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int ArmySizeMin = 50_000;
        public const int ArmySizeMax = 10_000_000;

        //Manufacturer
        public const int ManufacturerNameMin = 4;
        public const int ManufacturerNameMax = 40;
        public const int FoundedMin = 10;
        public const int FoundedMax = 100;

        //Shell
        public const double ShellWeightMin = 2;
        public const double ShellWeightMax = 1_680;
        public const int CaliberMin = 4;
        public const int CaliberMax = 30;

        //Gun
        public const int GunWeightMin = 100;
        public const int GunWeightMax = 1_350_000;
        public const double BarrelLengthMin = 2.00;
        public const double BarrelLengthMax = 35.00;
        public const int RangeMin = 1;
        public const int RangeMax = 100_000;
    }
}
