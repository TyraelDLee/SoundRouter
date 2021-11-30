# SoundRouter
If you have more than one monitor and multiple sound output device (like monitor built-in speaker) and 
you want to switch sound output device automatically corresponding to which monitor is app window currently on. 
Then SoundRouter could help you to do so. 
<br>
<br>
i.e.
video playing on display 1 and sound output device is display 1 built-in speaker; Move video to display 2 then sound output device will switch to display 2 built-in speaker.
<br>
<br>
Can help you switch audio output device for each app on different monitor.
<br>
GUI development is under progress.
<br>
## Config
Currently, you need config to source to suit your evnirement.
Modify those two value in ThreadWorker class. _command is the SoundVolumeView location. _audioDevices is the is your audio output device IDs, the order is corresponding to your display order (1st id the audio output device for display 1, 2ed  id the audio output device for display 2 and so on...). You can find those ids in your device manager.
```c#
    public class ThreadWorker
    {
        private volatile string _command = "...\\sv.exe";
        private volatile string[] _audioDevices = new string[]{"{0.0.0.00000000}.{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}", "{0.0.0.00000000}.{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}"};
        
```
<br><br>
This software need [SoundVolumeView](https://www.nirsoft.net/utils/sound_volume_view.html) to run.
