removeClassChanges: class
	"Remove all memory of changes associated with this class"

	classChanges removeKey: class name ifAbsent: [].
	methodChanges removeKey: class name ifAbsent: [].
	classRemoves remove: class name ifAbsent: [].