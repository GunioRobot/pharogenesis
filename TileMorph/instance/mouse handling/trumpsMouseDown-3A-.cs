trumpsMouseDown: evt
	"Return true if this morph wants to handle mouse down events even when the mouse is pressed under a submorph that also wishes to preepmpt mouse down events. Complete the comment."

	| aPoint |
	upArrow ifNotNil:
		[(upArrow boundsInWorld containsPoint: (aPoint _ evt cursorPoint))
			ifTrue: [^ true].
		(downArrow boundsInWorld containsPoint: aPoint)
			ifTrue: [^ true]].

	^ false
