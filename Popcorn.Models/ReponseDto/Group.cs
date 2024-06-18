namespace Popcorn.Models.ReponseDto
{
    public class Group
    {
        public string id { get; set; }
        public string title { get; set; }
        public string title_episode { get; set; }
        public string title_uri { get; set; }
        public string title_original { get; set; }
        public string description { get; set; }
        public string description_large { get; set; }
        public object short_description { get; set; }
        public string image_large { get; set; }
        public string image_medium { get; set; }
        public string image_small { get; set; }
        public string image_still { get; set; }
        public string image_background { get; set; }
        public string url_imagen_t1 { get; set; }
        public string url_imagen_t2 { get; set; }
        public string image_base_horizontal { get; set; }
        public string image_base_vertical { get; set; }
        public string image_base_square { get; set; }
        public string image_clean_horizontal { get; set; }
        public string image_clean_vertical { get; set; }
        public string image_clean_square { get; set; }
        public string image_sprites { get; set; }
        public string image_frames { get; set; }
        public string image_trickplay { get; set; }
        public object image_external { get; set; }
        public string duration { get; set; }
        public string date { get; set; }
        public string year { get; set; }
        public string preview { get; set; }
        public string season_number { get; set; }
        public string episode_number { get; set; }
        public string format_types { get; set; }
        public string live_enabled { get; set; }
        public object live_type { get; set; }
        public object live_ref { get; set; }
        public string source_uri { get; set; }
        public object timeshift { get; set; }
        public int votes_average { get; set; }
        public string rating_code { get; set; }
        public string proveedor_name { get; set; }
        public string proveedor_code { get; set; }
        public EncoderTecnology encoder_tecnology { get; set; }
        public RecorderTechnology recorder_technology { get; set; }
        public object resource_name { get; set; }
        public object rollingcreditstime { get; set; }
        public object rollingcreditstimedb { get; set; }
        public bool is_series { get; set; }
        public object channel_number { get; set; }
    }
}
