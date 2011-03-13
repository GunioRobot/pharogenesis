trumpsMouseDown: evt
	"Return true if this morph wants to handle mouse down events even when the mouse is pressed under a submorph that also wishes to preepmpt mouse down events. Complete the comment."

	| aPoint |
	upArrow ifNotNil:
		[(upArrow containsPoint: (aPoint _ evt cursorPoint))
			ifTrue: [^ true].
		(downArrow containsPoint: aPoint)
			ifTrue: [^ true]].

	^ false
