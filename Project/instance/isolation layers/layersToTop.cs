layersToTop
	"Return an OrderedCollection of all the projects that are isolation layers from this one up to the top of the project hierarchy, inclusive."

	| layers |
	self isTopProject
		ifTrue: [layers _ OrderedCollection new]
		ifFalse: [layers _ parentProject layersToTop].
	isolatedHead ifTrue: [layers addFirst: self].
	^ layers
