repelsMorph: aMorph event: ev
	aMorph willingToBeEmbeddedUponLanding ifFalse: [^ false].
	self dragNDropEnabled ifFalse: [^ true].
	(self wantsDroppedMorph: aMorph event: ev) ifFalse: [^ true].
	^ super repelsMorph: aMorph event: ev "consults #repelling flag"