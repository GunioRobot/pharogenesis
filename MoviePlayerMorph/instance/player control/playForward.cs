playForward
	(playDirection ~= 0 or: [frameNumber >= frameCount]) ifTrue:
		[^ self]. "No-op during play or at end"
	playDirection := 1.
	self startRunning