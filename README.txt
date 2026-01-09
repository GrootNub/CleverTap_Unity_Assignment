# Unity Weather App with Toast / Snackbar Package

## Project Overview

This project is a Unity-based mobile application developed as part of a technical assignment.  
It demonstrates:

- A reusable **Unity Package** that exposes a Game Object for displaying platform-specific **Toast / Snackbar** messages.
- A **Weather App** that fetches and displays real-time weather information based on the user’s location.

The solution emphasizes clean architecture, platform awareness (Unity Editor vs Mobile), and testability.

---

## Features

- Reusable Unity Package with a Game Object for Toast / Snackbar display
- Platform-specific behavior:
  - **Android**: Native Toast
  - **iOS**: Native Snackbar / Alert equivalent
  - **Unity Editor**: Console log fallback
- Captures user latitude and longitude
- Fetches weather data using the Open-Meteo Weather API
- Displays **current temperature** using the Toast package
- Android runtime permission handling
- Editor-safe mock location for development
- Unit tests using Unity Test Framework (EditMode)

---

## Weather App Implementation

### Location Handling

#### Android / iOS
- Uses `Input.location`
- Requests runtime location permission on Android
- Retrieves real GPS latitude and longitude on supported devices

#### Unity Editor
- Uses a mock location (Kanpur / Mumbai, India)
- Required because Unity Editor does not provide real GPS data

Using a mock location ensures the application remains testable during development without requiring a physical device.

---

## Weather API

- **API Provider:** Open-Meteo  
- **Endpoint:**  
https://api.open-meteo.com/v1/forecast



### Data Usage
- The API is called at runtime using the captured latitude and longitude.
- The JSON response is parsed into strongly-typed model classes.
- The **current temperature** is extracted and displayed using the Toast package.

> **Note:**  
> The sample JSON provided in the assignment demonstrates daily maximum temperature.  
> Since the requirement specifies showing the *current temperature*, the implementation uses the appropriate real-time weather data from the API.

---

## Architecture

The project follows a clean, layered architecture:

### Controller Layer
- Handles user interactions
- Coordinates services and UI
- Example: `WeatherController`

### Service Layer
- `LocationService`
- Handles GPS access and runtime permissions
- `WeatherService`
- Builds API URLs
- Performs network requests
- Parses weather JSON responses

### Model Layer
- Plain data classes representing API responses

### Package Layer
- Encapsulates Toast / Snackbar logic
- Platform-specific implementations
- Reusable across multiple projects

This separation improves maintainability, scalability, and testability.

---

## Toast / Snackbar Unity Package

### Usage

1. Add the Toast package to the project.
2. Add the `ToastView` Game Object to the scene.
3. Call the following method from any script:


