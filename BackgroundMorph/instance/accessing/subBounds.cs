subBounds
	"calculate the submorph bounds"

	| subBounds |
	subBounds := nil.
	self submorphsDo: 
			[:m | 
			subBounds := subBounds isNil
						ifTrue: [m fullBounds]
						ifFalse: [subBounds merge: m fullBounds]].
	^subBounds