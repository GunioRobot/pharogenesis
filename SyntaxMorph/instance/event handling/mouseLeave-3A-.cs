mouseLeave: evt
	"Move grab highlight back out a level"

"Transcript cr; print: self; show: ' leave'."
	self unhighlight.
	(owner ~~ nil and: [owner isSyntaxMorph])
		ifTrue: [owner highlightForGrab: evt].

