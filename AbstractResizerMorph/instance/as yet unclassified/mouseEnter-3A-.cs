mouseEnter: anEvent

	self isCursorOverHandle ifTrue:
		[self setInverseColors.
		self changed.
		anEvent hand showTemporaryCursor: self resizeCursor]