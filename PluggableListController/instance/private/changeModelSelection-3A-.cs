changeModelSelection: anInteger
	"Let the view handle this."

	terminateDuringSelect ifTrue: [self controlTerminate].
	view changeModelSelection: anInteger.
	terminateDuringSelect ifTrue: [self controlInitialize].