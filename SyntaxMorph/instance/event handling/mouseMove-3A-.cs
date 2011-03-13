mouseMove: evt
	| dup selection |
	owner isSyntaxMorph ifFalse: [^ self].
	self currentSelectionDo:
		[:innerMorph :mouseDownLoc :outerMorph |
		mouseDownLoc ifNotNil: [
			(evt cursorPoint dist: mouseDownLoc) > 4 ifTrue:
				["If drag 5 pixels, then tear off a copy of outer selection."
				selection _ outerMorph ifNil: [self].
				evt hand attachMorph: (dup _ selection duplicate).
				dup align: dup topLeft with: evt hand position + self cursorBaseOffset.
				self setSelection: nil.	"Why doesn't this deselect?"
				(self firstOwnerSuchThat: [:m | m isSyntaxMorph and: [m isBlockNode]])
					ifNotNilDo: [:m | "Activate enclosing block."
								m startStepping]]]].
