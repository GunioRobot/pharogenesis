maybeCollapse: evt with: collapseHandle
	"Ask hand to collapse my target if mouse comes up in it."
	evt hand obtainHalo: self.
	(collapseHandle containsPoint: evt cursorPoint)
		ifFalse:
			[self delete.
			target addHalo: evt]
		ifTrue:
			[self delete.
			target collapse]