doGrab: evt with: grabHandle
	"Ask hand to grab my target."

	self removeAllHandlesBut: grabHandle.  "remove all other handles"
	evt hand grabMorph: target.
