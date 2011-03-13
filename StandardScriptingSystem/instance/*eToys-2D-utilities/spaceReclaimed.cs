spaceReclaimed
	"Reclaim space from the EToy system, and return the number of bytes reclaimed"
	"ScriptingSystem spaceReclaimed"

	| oldFree  |
	oldFree _ Smalltalk garbageCollect.
	ThumbnailMorph recursionReset.
	Player removeUninstantiatedSubclassesSilently.
	Smalltalk cleanOutUndeclared.
	Smalltalk reclaimDependents.
	^ Smalltalk garbageCollect - oldFree.