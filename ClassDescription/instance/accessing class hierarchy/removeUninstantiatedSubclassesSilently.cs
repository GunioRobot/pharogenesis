removeUninstantiatedSubclassesSilently
	"Remove the classes of any subclasses that have neither instances nor subclasses.  Answer the number of bytes reclaimed"
	"Player removeUninstantiatedSubclassesSilently"

	| candidatesForRemoval  oldFree |

	oldFree _ self environment garbageCollect.
	candidatesForRemoval _
		self subclasses select: [:c |
			(c instanceCount = 0) and: [c subclasses size = 0]].
	candidatesForRemoval do: [:c | c removeFromSystem].
	^ self environment garbageCollect - oldFree