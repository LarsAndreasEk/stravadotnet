stravadotnet
============

Hopefully this small framework makes using the Strava API a little bit easier!

About this Readme
============

The last couple of weeks i focused on the framework itself, so i haven't had much time to write a Readme file.
In the Program.cs file, you will find a few samples on how to use the framework.

Hints
============
Authentication
--------------

When using the WebAuthentication method in your application, you have to start the application as an admin (at least when you acquire the access token). Strava sends back the access token via a callback. To receive this callback, a WebServer must be started locally. To start such a server, you need admin rights.

After you have received your token, you can save it to a file so you won't have to get a new token every time.


Feedback
============

If you have any feedback, bug reports or suggestions, feel free to send me an email.
My mail address is bike (at) sascha-simon (dot) com.
