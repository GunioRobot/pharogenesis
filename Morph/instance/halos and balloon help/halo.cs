halo

	(self world ifNil: [^nil]) haloMorphs do: [:h | h target == self ifTrue: [^ h]].
	^ nil