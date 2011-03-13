removeNamedClassChanges: className
	"Remove all memory of changes associated with this class name.
	This is here as removeClassChanges: will not work if the class
	has been removed."

	classChanges removeKey: className ifAbsent: [].
	methodChanges removeKey: className ifAbsent: [].
	classRemoves remove: className ifAbsent: [].