clearCachesFor: anObject 
	"Clear the valid caches."

	anObject isPackage ifTrue:[packages _ nil].
	anObject isAccount ifTrue:[accounts _ users _ nil].
	anObject isCategory ifTrue:[categories _ nil]
