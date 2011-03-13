newDepthNoRestore: pixelSize
	depth = pixelSize ifTrue: [^ self  "no change"].
	self depth: pixelSize.  self setExtent: self extent.
	ScheduledControllers updateGray.
	DisplayScreen startUp