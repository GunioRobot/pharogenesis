newDepth: pixelSize
"
	Display newDepth: 8.
	Display newDepth: 1.
"
	self newDepthNoRestore: pixelSize.
	ControlManager shutDown; startUp.