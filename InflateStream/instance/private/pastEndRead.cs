pastEndRead
	"A client has attempted to read beyond the read limit.
	Check in what state we currently are and perform
	the appropriate action"
	| blockType |
	state = StateNoMoreData ifTrue:[^nil]. "Get out early if possible"
	"Check if we can move decoded data to front"
	self moveContentsToFront.
	"Check if we can fetch more source data"
	self moveSourceToFront.
	state = StateNewBlock ifTrue:[state _ self getNextBlock].
	blockType _ state bitShift: -1.
	self perform: (BlockTypes at: blockType+1).
	^self next