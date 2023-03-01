namespace P02_FootballBetting.Data.Common
{
    public static class ValidationConstants
    {
        //Teams
        public const int TeamMaxLength = 60;
        public const int TeamMaxUrlLength = 2048;
        public const int TeamMaxInitialsLength = 6;

        //Color
        public const int ColorMaxLength = 20;

        //Town
        public const int TownNameMaxLength = 60;

        //Coutry
        public const int CountryNameMaxLength = 60;

        //Player
        public const int PlayerNameMaxLength = 90;

        //Position
        public const int PositionNameMaxLength = 30;

        //Game
        public const int GameResultMaxLength = 10;

        //User
        public const int UserUsernameMaxLength = 40;
        public const int UserPasswordMaxLength = 255;
        public const int UserEmailMaxLength = 255;
        public const int UserNameMaxLength = 90;

    }
}
