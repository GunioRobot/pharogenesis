removeUninstantiatedSubclassesSilently
	"Remove the classes of any subclasses that have neither instances nor subclasses.  Answer the number of bytes reclaimed"
	"Player removeUninstantiatedSubclassesSilently"

	| candidatesForRemoval  oldFree |

	oldFree _ Smalltalk garbageCollect.
	candidatesForRemoval _ OrderedCollection new.
	self allSubclassesWithLevelDo: [:e :l | candidatesForRemoval add: e] startingLevel: 2.
	candidatesForRemoval _ candidatesForRemoval reverse.
	candidatesForRemoval _
		candidatesForRemoval select: [:c |
			(c instanceCount = 0) and: [c subclasses size = 0]].
	candidatesForRemoval _ candidatesForRemoval select:
		[:aClass | aClass isSystemDefined not].
	candidatesForRemoval do: [:c | c removeFromSystemUnlogged].
	^ Smalltalk garbageCollect - oldFree