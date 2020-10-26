# Sample mask
.NET Core application for encrypting audio in audio files.

## Description
This utility encrypts audio in audio files by inverting the audio signal spectrum. For now, the program can only work with Wave format audio files. The coding depth of the target file is 16 bit, mono, the sampling rate is recommended not less than 44100 Hz. To decrypt the file, you need to run it through this algorithm again. Thus, the information in the protected audio file will turn into a set of noise, and the file will remain readable.

## How it works?
The application reads data from an audio file, converts binary data into an audio signal. A discrete Fourier transform is performed on the received signal, as a result of which the expansion coefficients are obtained. Further, the obtained coefficients are rearranged in the reverse order. Then the inverse discrete Fourier transform is performed, after which the audio signal spectrum becomes inverse with respect to the original one. Next, the program digitizes the resulting signal and writes it to a new audio file, while keeping the original title.

## Usage
The program interface allows you to open the target file using a dialog box or by manually entering the path. The application will offer three options: convert the file by opening it through the dialog box, convert the file by manually entering the path to it, and exit the program. In the first two options, the program will offer to select the target file in the file system of your computer, and in case of successful conversion, it will offer to select the path to save it. An example of the program is shown below:

![Screenshot with the program](.github/Screen.png)

## Thanks
This project is a software implementation of the method for masking analog speech signals described in the patent of the Russian Federation №2546614.

## Licensing
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Flight-hat%2Fsample-mask.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Flight-hat%2Fsample-mask?ref=badge_large)
