methodHierarchy
	"Create and schedule a message browser on the hierarchical implementors."

	| aSel aClass |
	self controlTerminate.
	aSel _ model selectedMessageName..
	aClass _ model selectedClassOrMetaClass.
	((aSel ~~ nil) & (aClass ~~ nil)) ifTrue:
		[Utilities methodHierarchyBrowserForClass: aClass selector: aSel].
	self controlInitialize