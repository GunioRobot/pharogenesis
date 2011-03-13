maybeDismiss: evt with: dismissHandle
	"Ask hand to dismiss my target if mouse comes up in it."
	evt hand obtainHalo: self.
	(dismissHandle containsPoint: evt cursorPoint)
		ifFalse:
			[self delete.
			target addHalo: evt]
		ifTrue:
			[self delete.
			target dismissViaHalo]