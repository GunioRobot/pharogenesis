classHierarchy
	"Create and schedule a class list browser on the receiver's hierarchy."

	| aSel aClass |
	self controlTerminate.
	aSel _ model selectedMessageName..
	aClass _ model selectedClassOrMetaClass.
	((aSel ~~ nil) & (aClass ~~ nil)) ifTrue:
		[Utilities spawnHierarchyForClass: aClass selector: aSel].
	self controlInitialize