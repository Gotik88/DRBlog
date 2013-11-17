namespace DR.Configuration.Settings
{
    public class Setting
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public string SectionName { get; set; }

        public ConfigurationType ConfigurationType { get; set; }
    }
}
