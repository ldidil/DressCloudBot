# DressCloudBot

 ## Technologies
* Language: C#
* Selenium WebDriver

## Overview

The software is a bot that logs into the user's account of DressCloud.pl portal.
It automaticly collects the activity points by emulating user action of clicking "crystals".
The user may select starting and final page in the portal, where the action should be performed.

## Setup
To run this project properly, add appropriate values to the variables below

```

        readonly string login;
        readonly string password;

        int numberStartPage;
        int numberStopPage;


```
