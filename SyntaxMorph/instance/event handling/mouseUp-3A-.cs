mouseUp: evt
	| newSel |
	self rootTile isMethodNode ifFalse: [^ self].
	self currentSelectionDo:
		[:innerMorph :mouseDownLoc :outerMorph |
		newSel _ outerMorph
			ifNil: [self "first click"]
			ifNotNil: [(outerMorph firstOwnerSuchThat:
							[:m | m isSyntaxMorph and: [m isSelectable]]) ifNil: [self]].
		newSel isMethodNode ifTrue: [^ self setSelection: nil].
		self setSelection: {self. nil. newSel}]
