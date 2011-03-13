halo
	self world haloMorphs do:
		[:h | h target == self ifTrue: [^ h]].
	^ nil