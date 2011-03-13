justDroppedInto: aMorph event: evt
	aMorph isSyntaxMorph ifFalse:
		["Drop my topLeft at the tip of the cursor if not in a scriptor."
		self align: self topLeft with: self topLeft - self cursorBaseOffset].
	self removeProperty: #beScript.
	^ super justDroppedInto: aMorph event: evt