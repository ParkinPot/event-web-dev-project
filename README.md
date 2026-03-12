# Event Web Development Project

A comprehensive web application designed for organizing and managing local events and social activities. This platform facilitates user engagement through event creation, membership applications, and a robust notification system.

## Project Structure

The application is built using a clean ASP.NET Core MVC architecture, following a logical separation of concerns:

- **Controllers/**: Handles incoming HTTP requests and manages the application logic.
- **Models/**: Defines the data structures and domain objects.
- **Views/**: Contains Razor templates for rendering the user interface.
- **Data/**: Manages database context and migrations using Entity Framework Core.
- **Services/**: Includes background tasks and specialized application services.
- **wwwroot/**: Hosts static assets including CSS, JavaScript, and images.

## Core Functionality

### User Management
- **Identity Integration**: Secure authentication and authorization using Microsoft ASP.NET Core Identity.
- **Profile Customization**: Users can manage their personal profiles, including avatars, tags, and interests.

### Event & Activity Management
- **Event Creation**: Users can create activity posts with detailed descriptions, location, and member limits.
- **Join System**: A managed application flow where users can apply to join events.
- **Status Tracking**: Real-time status updates for events (Open, Full, Expired).

### Engagement Tools
- **Invitation System**: Facilitates personal invitations to activities.
- **Notification System**: Real-time popups and a persistent panel for tracking invitation and application status.
- **Review System**: Allows participants to leave feedback on completed activities.

## AJAX Implementation

The project leverages modern JavaScript `fetch` API for a seamless, SPA-like experience in several key areas:

### Notification System
- **Real-time Polling**: The application polls the server every 30 seconds for unread notifications without requiring a page refresh.
- **Asynchronous Actions**: Marking notifications as read and dismissing toasts are handled via background POST requests.

### Event Interactions
- **Application Submission**: Submitting a request to join an activity is handled asynchronously, providing immediate user feedback via toast notifications.
- **Invitation Responses**: Accepting or declining invites on the "My Board" page is performed via AJAX, updating the UI state dynamically.

### Profile Management
- **State Synchronization**: Hidden fields and asynchronous updates ensure profile changes are reflected accurately.

## Technology Stack

- **Backend**: ASP.NET Core 10.0
- **Database**: PostgreSQL with Entity Framework Core
- **Frontend**: Vanilla JavaScript and CSS
- **Containerization**: Docker support for simplified deployment
