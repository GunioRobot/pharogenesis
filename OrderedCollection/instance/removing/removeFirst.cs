removeFirst
	"Remove the first element of the receiver and answer it. If the receiver is 
	empty, create an error notification."
	| firstObject |
	self emptyCheck.
	firstObject _ array at: firstIndex.
	array at: firstIndex put: nil.
	firstIndex _ firstIndex + 1.
	^ firstObject