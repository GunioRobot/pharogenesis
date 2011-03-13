serveOnPort: portNumber loggingTo: fileName
	"Start up the HTTP server loop for the given port number and log file."

	self stopServer.
	Socket initializeNetwork.
	ServerLog _ FileStream fileNamed: fileName.
	ServerLog position: ServerLog size.
	ServerPort _ ConnectionQueue portNumber: portNumber queueLength: 6.
	ClientNameCache _ Dictionary new.

	ServerProcess _ [self loopOnPort: portNumber loggingTo: fileName] newProcess.
	ServerProcess priority: Processor lowIOPriority.
	ServerProcess resume.
