endEntry
	"Display all the characters since the last endEntry, and reset the
	stream "
	
	accessSemaphore critical: [
		self changed: #appendEntry.
		World displayWorldSafely.
		stream resetContents]