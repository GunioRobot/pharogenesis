removeUninstantiatedModelsSilently
	"Remove the classes of any models that have neither instances nor subclasses.  Answer the number of bytes reclaimed"
	"MorphicModel removeUninstantiatedModelsSilently"

	| candidatesForRemoval  oldFree |

	oldFree _ Smalltalk garbageCollect.
	candidatesForRemoval _
		MorphicModel subclasses select: [:c |
			(c instanceCount = 0) and: [c subclasses size = 0]].
	candidatesForRemoval do: [:c | c removeFromSystem].
	^ Smalltalk garbageCollect - oldFree