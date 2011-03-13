associationDeclareAt: aKey
	"Return an existing association, or create and return a new one.  Needed as a single message by ImageSegment.prepareToBeSaved."

	| existing |
	^ self associationAt: aKey ifAbsent: [
		(Undeclared includesKey: aKey)
			ifTrue: 
				[existing := Undeclared associationAt: aKey.
				Undeclared removeKey: aKey.
				self add: existing]
			ifFalse: 
				[self add: aKey -> false]]