trace: aBlock onFileNamed: fileName		"ContextPart trace: [3 factorial] onFileNamed: 'trace'"
	"This method uses the simulator to print calls to a file."

	| aStream |
	^ [aStream _ FileStream fileNamed: fileName.
		self trace: aBlock on: aStream] ensure: [aStream close]