acceptsLoggingOfCompilation
	"Dont log sources for my automatically-generated subclasses.  Can easily switch this back when it comes to deal with Versions, etc."

	self flag: #deferred.
	^ self == MorphicModel or:
		[(self class name beginsWith: 'Morphic') not]