# CinemaReconstructionInVr

We've created a reconstruction of the movie theater 'Flamman' in Virtual Reality. 

To download only the executable, see [releases](https://github.com/jpettson/CinemaReconstructionInVR/releases/latest).

## Repository structure

-   `build/` - This is where the executable as well as the 'data' folder is contained.

    -   `Cinema Reconstruction in VR_Data/` - Contains the necessary files for running the program, as well as any additional movies.

-   `assets/` - Contains a standard Unity-type project structure.

## External links

[Trello for Scrum backlog.](https://trello.com/b/nBZEuc63/datx02-kandidat)

Link to the paper on this project: pending.

[SteamVR.](https://store.steampowered.com/app/250820/SteamVR/)

## Running the application

To run this application, SteamVR is required.

### Adding additional movies

To add additional movies other than the default ones, simply put your movie-files into the `Cinema Reconstruction in VR_Data/StreamingAssets` - folder inside `build/`.
The following formats are accepted: `.mp4`, `.mov` and `.wmv`.

### Run exe

To run the program simply run the executable located inside `build/`.

### Build from source code

To build from source code, download and open the project with Unity and then build `MainScene.unity`.

### Connecting to others

To connect to other players using the application, the host will need to open port 7777(TCP/UDP) in their router. After this is done, run the application, select host and client.
To connect to the host, enter the hosts public IP-address in the textbar and press connect. 

## Authors

| Namn               | Github-nick   |
| ----------------   | ------------- |
| Joakim Burman      | burmanj       |
| Jonathan Eksberg   | eksberg       |
| Mirai Ibrahim      | pepsilover    |
| Tommi-Roy Karlsson | tommiroy      |
| Johan Pettersson   | jpettson      |
| Adam Rohdell       | AdamRohdell   |
