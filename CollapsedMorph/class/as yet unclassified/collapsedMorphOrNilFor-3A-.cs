collapsedMorphOrNilFor: anActualMorph
	"If there is any instance of the receiver that represents anActualMorph, answer it, else answer nil"

	self allInstances do:
		[:cm | (cm isMyUncollapsedMorph: anActualMorph)
			ifTrue:	[^ cm]].
	^ nil