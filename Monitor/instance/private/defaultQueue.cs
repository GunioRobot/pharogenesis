defaultQueue
	defaultQueue ifNil: [defaultQueue _ OrderedCollection new].
	^ defaultQueue