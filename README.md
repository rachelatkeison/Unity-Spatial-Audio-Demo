# Yamaha DSP / MR Portfolio Demo  

**Candidate:** Rachel Atkeison  

## Project Overview  
This project demonstrates skills in **Digital Signal Processing (DSP)**, **spatial audio**, and **mixed reality (MR) content creation**, aligned with Yamaha’s **Sound xR Core** and **MR initiatives**.  

The program generates a stereo WAV file with multiple DSP techniques applied, suitable for direct import into Unity or further MR/XR development.  

## Features  
- **Stereo binaural audio**: Two tones moving dynamically across left/right channels  
- **Harmonics**: Adds richness to pure tones for a professional sound  
- **Low-pass filters**: Smoothens harsh frequencies using biquad filters  
- **Tremolo**: Adds rhythmic modulation and movement  
- **Fade in / Fade out**: Eliminates clicks for polished audio transitions  
- **Stereo panning**: Simulates spatial positioning for MR/XR use cases  
- **WAV output**: Produces `stereo_demo.wav` for testing and integration  

---

## Project Structure  
YamahaDSPDemo/
│
├── Program.cs           # Main stereo DSP demo
├── BiquadFilter.cs      # Low-pass filter class
├── YamahaDSPDemo.csproj # .NET console application project file
└── stereo\_demo.wav      # Generated audio output

## Requirements  
- .NET 6.0 SDK or later  
- Visual Studio or VS Code (optional)  
- Audio player for WAV file playback  

## How to Run  

1. Clone or unzip the project:  
   git clone <repo-url>
   cd YamahaDSPDemo

2. Build the project:
   dotnet build
   
4. Run the demo:
   dotnet run

5. The program generates:
   stereo_demo.wav
   
This file can be played back directly or imported into Unity for spatial audio testing.

---

## Notes

This demo is intended as a **technical showcase** of DSP and MR audio techniques and may be extended for real-time or multi-channel applications.
