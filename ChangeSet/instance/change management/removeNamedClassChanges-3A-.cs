removeNamedClassChanges: className
	"Remove all memory of changes associated with this class name.
	This is here as removeClassChanges: will not work if the class
	has been removed."

	self flag: #deferred.  "No senders; fix-up"
	classChanges removeKey: className ifAbsent: [].
	methodChanges removeKey: className ifAbsent: [].
	classRemoves remove: className ifAbsent: [].