targets
	"Answer my targets, initializing them to an empty collection if found to be nil"

	^ targets ifNil: [targets _ OrderedCollection new]