# Myflix Video Catalogue

## Description

A microservice apart of `Myflix` project which servers as a video catalogue service.
The service is built using ASP.NET Core, Entity Framework, MSSql Server and Docker.

## Features

- **Show Video Catalogue**: Handle requests for the video catalogue.

## Deployment

### Using Docker:
1. Build the Docker image from `Dockerfile` in `/src` folder.

```bash
docker build -t {image-name} .
```

2. Run the docker image.

```bash
docker run -p 5000:5000 --name {container-name} {image-name}
```

## Usage

### View Video Catalogue

#### Request

`GET` `/api/videos`

#### Response

```json
[
    {
        "Id": 1,
        "Title": "Sample Video",
        "Description": "This is a sample video description.",
        "Author": "John Doe",
        "Length": 120,  // Length in seconds
        "VideoUrl": "sample-video.mp4"
    },
    {
        "Id": 2,
        "Title": "Sample Video 2",
        "Description": "This is a sample video description.",
        "Author": "John Doe",
        "Length": 120,  // Length in seconds
        "VideoUrl": "sample-video2.mp4"
    }
]
```

 
