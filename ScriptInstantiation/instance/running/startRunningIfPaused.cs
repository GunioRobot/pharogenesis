startRunningIfPaused
	"If the receiver is paused, start it ticking"

	status == #paused ifTrue:
		[status _ #ticking.
		self updateAllStatusMorphs]