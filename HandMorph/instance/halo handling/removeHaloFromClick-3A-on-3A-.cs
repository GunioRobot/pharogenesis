removeHaloFromClick: anEvent on: aMorph
	| halo |
	halo _ self halo ifNil:[^self].
	(halo target hasOwner: self) ifTrue:[^self].
	(halo staysUpWhenMouseIsDownIn: aMorph) ifFalse:[
		halo delete.
		self removeProperty: #halo.
	].