initialize
	AllChangeSets == nil ifTrue:
		[AllChangeSets _ OrderedCollection new].
	self gatherChangeSets.
