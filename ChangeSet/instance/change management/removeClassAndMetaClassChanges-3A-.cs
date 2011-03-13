removeClassAndMetaClassChanges: class
	"Remove all memory of changes associated with this class and its metaclass.  7/18/96 sw"

	classChanges removeKey: class name ifAbsent: [].
	methodChanges removeKey: class name ifAbsent: [].
	classChanges removeKey: class class name ifAbsent: [].
	methodChanges removeKey: class class name ifAbsent: [].
	classRemoves remove: class name ifAbsent: [].