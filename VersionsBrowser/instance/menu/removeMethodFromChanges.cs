removeMethodFromChanges
	"Remove my method from the current change set"

	Smalltalk changes removeSelectorChanges: selectorOfMethod class: classOfMethod.
	self changed: #annotation
