public class SliderFXSoundUI : BaseSlider
{
    public override void ValueChangeCheck()
    {
        AudioManager.Instance.FXAudio(_slider.value);
    }
}