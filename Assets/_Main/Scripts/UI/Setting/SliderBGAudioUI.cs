public class SliderBGAudioUI : BaseSlider
{
    public override void ValueChangeCheck()
    {
        AudioManager.Instance.BGAudio(_slider.value);
    }
}