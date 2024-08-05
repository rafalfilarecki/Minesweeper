# Minesweeper in C# with WPF

## Table of Contents
- [Project Description](#project-description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Future Extensions](#future-extensions)
- [Author](#author)

## Project Description
Minesweeper is a popular logic game where the objective is to uncover all the squares on a grid that do not contain mines. In this project, the game has been implemented in C# using WPF (Windows Presentation Foundation) to create the user interface.

## Features
- **Dynamic Game Settings:** The user can choose the size of the grid and the number of mines before starting the game.
- **User Interface:** The game uses WPF to create a user-friendly interface, where each cell is represented by a button.
- **Flagging Cells:** The user can mark cells as mined using the right mouse button.
- **Indicators:** Displaying the number of mines and the number of flagged cells.
- **Event Handling:** Implementation of left click, right click.
- **Game Over:** After winning or losing, a new window displays the game result with buttons to start a new game, restart the same game, or end the game.

## Installation
To run the project locally, follow these steps:

1. **Clone the repository:**
    ```bash
    git clone https://github.com/rafalfilarecki/Minesweeper.git
    cd Minesweeper
    ```

2. **Open the project in Visual Studio:**
    - Launch Visual Studio.
    - Select "Open a project or solution".
    - Locate and select the `.sln` file in the `Minesweeper` folder.

3. **Run the project:**
    - Press `F5` or click "Start" in Visual Studio to build and run the application.

## Usage
1. After launching the application, the user will see a window where they can select the grid size and the number of mines.
2. Click the "Start" button to begin the game.
3. Left-click to reveal a cell.
4. Right-click to mark a cell as mined (flag).
5. After the game ends, a window will display the result with buttons:
   - "New Game" - Start a new game.
   - "Restart" - Restart the same game.
   - "End Game" - End the game.

## Project Structure
- **MainWindow.xaml:** XAML definition for the main window interface.
- **MainWindow.xaml.cs:** Code-behind for MainWindow.xaml, handles the initialization and starting the game.
- **GameWindow.xaml:** XAML definition of the game interface.
- **GameWindow.xaml.cs:** Code-behind for GameWindow.xaml, contains the logic for handling the user interface.
- **GameOverWindow.xaml:** Window displayed at the end of the game.
- **GameOverWindow.xaml.cs:** Code-behind for GameOverWindow.xaml, contains the logic for handling buttons after the game ends.
- **Game.cs:** Contains the game logic, including methods for initializing the grid, revealing cells, flagging, and checking the game state.
- **Board.cs:** Represents the game board and contains information about the cells.
- **Cell.cs:** Represents a single cell on the game board.

## Future Extensions
- **Unit Tests:** Add unit tests for key game logic components.
- **Game Modes:** Introduce different difficulty levels.
- **UI Improvements:** Enhance the user interface for better user experience and visual appeal.
- **General Development:** Continuously improve the application by fixing bugs, enhancing existing features, and adding new functionalities.

## Author
This project was created by a computer science student to showcase programming skills and assist in securing a job.
