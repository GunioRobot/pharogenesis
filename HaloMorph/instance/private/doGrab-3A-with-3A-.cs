doGrab: evt with: grabHandle
	"Ask hand to grab my target."
	evt hand obtainHalo: self.
	self removeAllHandlesBut: grabHandle.  "remove all other handles"
	evt hand grabMorph: target.
	self step. "update position if necessary"
	evt hand addMouseListener: self. "Listen for the drop"