haloMorphOrNil
	| m |
	^ (m _ self haloMorphs) size > 0 ifTrue: [m first] ifFalse: [nil]