# ColorCorrection

## Project Description

ColorCorrection is a Windows Forms application developed in C# using .NET 8.0. The project provides a graphical user interface for performing various color correction operations on images. These operations include histogram equalization, histogram stretching, white balance adjustment, black balance adjustment, and conversion to grayscale. The application displays histograms and cumulative distribution functions (CDFs) for the red, green, and blue channels of the loaded image, providing visual feedback on the color distribution. Users can load images, save modified images (or save them with a different name), and create test images with a checkerboard pattern and an HSV gradient.  It leverages unsafe code blocks for efficient pixel-level manipulation.

## Table of Contents

1.  [Project Description](#project-description)
2.  [Table of Contents](#table-of-contents)
3.  [Installation Instructions](#installation-instructions)
4.  [Usage Guide](#usage-guide)
    *   [Opening an Image](#opening-an-image)
    *   [Saving an Image](#saving-an-image)
    *   [Creating a Test Image](#creating-a-test-image)
    *   [Histogram Equalization](#histogram-equalization)
    *   [Histogram Stretching](#histogram-stretching)
    *   [White and Black Balance](#white-and-black-balance)
    *   [Grayscale Conversion](#grayscale-conversion)

## Installation Instructions

1.  **Prerequisites:**
    *   .NET 8.0 SDK (with Windows Desktop Runtime).
    *   An IDE that supports .NET development, such as Visual Studio or JetBrains Rider.

2.  **Cloning the Repository:**

    ```bash
    git clone https://github.com/F1r3d3v/ColorCorrection.git
    cd ColorCorrection
    ```

3.  **Building the Project:**

    *   **Using Visual Studio:**
        1.  Open the `GK1-ColorCorrection.sln` file in Visual Studio.
        2.  Build the solution by selecting "Build" -> "Build Solution" from the menu.

    *   **Using the .NET CLI:**
        1.  Navigate to the project directory in your terminal.
        2.  Run the following command:
            ```bash
            dotnet build
            ```

4.  **Running the Application:**

    *   **Using Visual Studio:**
        1.  After a successful build, press F5 or select "Debug" -> "Start Debugging".

    *   **Using the .NET CLI:**
        1.  Navigate to the `bin/Debug/net8.0-windows` (or `bin/Release/net8.0-windows` if you built in Release mode) subdirectory within the project directory.
        2.  Run the executable: `GK1-ColorCorrection.exe`.

5. **Dependencies:**
    * This project has no external NuGet package dependencies.  It relies solely on the .NET 8.0 SDK and Windows Forms.

## Usage Guide

### Opening an Image

1.  Click on "File" in the menu bar.
2.  Select "Open...".
3.  Choose an image file (supported formats: JPG, JPEG, PNG, BMP) from the file dialog.
4.  The selected image will be displayed in the main window, and its histograms will be calculated and shown.  The application includes sample images (Lenna.png, Fruits.png, Mountains.jpg) in the `Images` directory.

### Saving an Image

1.  Click on "File" in the menu bar.
2.  Select "Save" to overwrite the currently loaded image, or "Save As..." to save the modified image to a new file.
3.  If you choose "Save As...", select a file name and location in the save dialog.

### Creating a Test Image

1.  Click "File" -> "Create".
2.  A dialog box will appear, allowing you to specify the width, height, and pattern size of the test image.
3.  Click "Set" (or press Enter).
4.  A checkerboard image with a superimposed HSV gradient will be generated.  The checkerboard pattern alternates between white and black squares. The gradient covers 1/9th of the image area, centered.

### Histogram Equalization

1.  Click the "Histogram equalization" button.
2.  The application will perform histogram equalization on the image, redistributing the pixel intensities to enhance contrast.
3.  The updated image and histograms will be displayed.

### Histogram Stretching

1.  Adjust the "Stretching threshold" using the numeric up-down control. This value (between 0 and 1) determines the percentage of pixels to ignore at the low and high ends of the histogram.
2.  Click the "Histogram streching" button.
3.  The application will stretch the histogram based on the specified threshold, enhancing contrast within the selected range.
4.  The updated image and histograms will be displayed.

### White and Black Balance

1.  **Setting White Reference:**
    *   Click the "White balance eyerdrop" button.
    *   Your cursor will change to an eyedropper.
    *   Left-click on a pixel in the image that should represent pure white.  Right-click to cancel.
    *   The selected color will be displayed in the "pWhiteReference" panel.

2.  **Setting Black Reference:**
    *   Click the "Black balance eyedrop" button.
    *   Your cursor will change to an eyedropper.
    *   Left-click on a pixel in the image that should represent pure black. Right-click to cancel.
    *   The selected color will be displayed in the "pBlackReference" panel.

3.  **Applying Balance Correction:**
    *   Click the "Apply balance correction" button.
    *   The image will be adjusted based on the selected white and black reference points.

### Grayscale Conversion

1.  Click the "Convert to grayscale" button.
2.  The application will convert the image to grayscale using the standard luminosity method (0.299\*R + 0.587\*G + 0.114\*B).
3.  The updated image and histograms will be displayed.
