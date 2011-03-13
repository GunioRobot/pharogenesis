addResource: aResource
	"Lazily initialize the resources collection."
	
	resources ifNil: [resources := OrderedCollection new].
	aResource object: self.
	^resources add: aResource