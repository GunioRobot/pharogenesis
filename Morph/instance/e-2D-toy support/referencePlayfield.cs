referencePlayfield
	| pf |
	owner ifNil: [self halt: 'no owner for morph'].
	owner isPlayfieldLike ifTrue: [^ owner].
	(owner isKindOf: HandMorph) ifTrue:
		[((pf _ owner formerOwner) ~~ nil and: [pf isPlayfieldLike]) ifTrue: [^ owner formerOwner]].
	self isInWorld ifFalse: [^ nil].
	^ self world submorphNamed: 'playfield'