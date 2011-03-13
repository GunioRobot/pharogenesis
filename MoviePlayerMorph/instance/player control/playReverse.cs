playReverse
	(playDirection ~= 0 or: [frameNumber <= 1]) ifTrue:
		[^ self]. "No-op during play or at end"
	playDirection := -1.
	self startRunning