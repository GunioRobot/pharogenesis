stopTicking
	"If I'm ticking stop, else do nothing"

	status == #ticking ifTrue:
		[status _ #paused.
		self updateAllStatusMorphs]