halo
	self currentWorld haloMorphs do:
		[:h | h target == self ifTrue: [^ h]].
	^ nil