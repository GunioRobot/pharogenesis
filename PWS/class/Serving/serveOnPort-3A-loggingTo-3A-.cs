serveOnPort: portNumber loggingTo: fileName
	"This is the outer HTTP server loop."

	[	self loopOnPort: portNumber loggingTo: fileName.
		ServerStatus = #snapshot ifTrue: [
			Smalltalk snapshot: true andQuit: false.].
		ServerStatus ~= #quit ] whileTrue
