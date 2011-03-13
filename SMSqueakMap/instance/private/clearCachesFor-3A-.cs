clearCachesFor: anObject 
	"Clear the valid caches."

	anObject isPackage ifTrue:[packages := nil].
	anObject isAccount ifTrue:[accounts := users := nil].
	anObject isCategory ifTrue:[categories := nil]
