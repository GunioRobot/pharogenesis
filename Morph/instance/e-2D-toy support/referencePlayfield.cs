referencePlayfield
	| former |
	owner ifNotNil:
		[owner isPlayfieldLike ifTrue: [^ owner].
		(owner isHandMorph and: [(former _ owner formerOwner) notNil])
			ifTrue:
				[^ former isPlayfieldLike 
					ifTrue: [former]
					ifFalse: [former referencePlayfield]]].
	self isInWorld ifFalse: [^ nil].
	^ self world submorphNamed: 'playfield'