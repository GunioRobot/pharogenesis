okayToAddGrabHandle
	"Answer whether a halo on the receiver should offer a grab handle.  This provides a hook for making it harder to deconstruct some strucures even momentarily"

	^ self holdsSeparateDataForEachInstance not 