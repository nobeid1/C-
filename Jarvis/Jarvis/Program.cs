using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;
namespace Jarvis
{
    class Program
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            List<string> cpuMaxOutMessages = new List<string>();
            cpuMaxOutMessages.Add("wARNING: oh my god you should not run your cpu so hard");
            cpuMaxOutMessages.Add("wARNING: oh my god you should not run your cpu so hard");
            cpuMaxOutMessages.Add("wARNINg: Stop downloading porn it burning the CPU");
           cpuMaxOutMessages.Add("wARNING: oh my god oh my god oh my god oh my god I farted");

            Random ran = new Random();
            #region

            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfCpuCount.NextValue();
            synth.Speak("Welcome to jarvis 1 point oh");

            PerformanceCounter perfUPtimeCount = new PerformanceCounter("System", "System Up time");
            #endregion
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfCpuCount.NextValue());
            string systemUptimeMessage = string.Format("The current system up time is {0} days {1} hours {2} minutes {3} seconds ",
                (int)uptimeSpan.TotalDays,
               uptimeSpan.Hours,
               uptimeSpan.Minutes,
               uptimeSpan.Seconds
             
                               );
            bool ischromeopen = false;
            synth.Speak(systemUptimeMessage);
            while (true)
            {
                //Every 1 second print the CPU load in percentage to the screen
                int currentCpuPercentage = (int)perfCpuCount.NextValue();
                int currentAvailableMemory = (int)perfMemCount.NextValue();
                Console.WriteLine("CPU Load: {0}%", currentCpuPercentage);
                Console.WriteLine("Available Memory: {0}MB", currentAvailableMemory);
                if (currentCpuPercentage > 20)
                {
                    if (currentCpuPercentage == 25)
                    {
                        synth.SelectVoiceByHints(VoiceGender.Female);
                        string cpuLoadVocalMessage = cpuMaxOutMessages[ran.Next(4)] ;
                        Speak(cpuLoadVocalMessage, VoiceGender.Female,5);
                        if (ischromeopen == false)
                        {
                            openwebsite("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                            ischromeopen = true;
                        }
                        }
                    else
                    {
                        string memAvailableVocalMessage = String.Format("You currently have {0} megabytes of memory available", currentAvailableMemory);

                        Speak(memAvailableVocalMessage, VoiceGender.Male, 5);

                    }
                }
                Thread.Sleep(1000);



            }
        }
            public static void Speak(string message, VoiceGender voiceGender)
            {
                synth.SelectVoiceByHints(voiceGender);

                synth.Speak(message);
            }
        public static void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);
        }
        public static void openwebsite(string URl)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URl;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();



        }



        }
}

