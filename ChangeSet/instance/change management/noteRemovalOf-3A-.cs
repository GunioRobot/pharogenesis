noteRemovalOf: aClass
	"The class is about to be removed from the system.  Adjust the receiver to reflect that fact."

	classChanges removeKey: aClass name ifAbsent: [].
	methodChanges removeKey: aClass name ifAbsent: [].
	classChanges removeKey: aClass class name ifAbsent: [].
	methodChanges removeKey: aClass class name ifAbsent: [].
	classRemoves add: aClass name