spawnHierarchyForClass: aClass selector: aSelector
	"Create and schedule a new class hierarchy browser on the requested class/selector."
	"SystemNavigation default spawnHierarchyForClass: SmallInteger selector: #hash"
	
	| newBrowser |
	(aClass == nil)  ifTrue: [^ self].
	(newBrowser _ Browser new) setClass: aClass selector: aSelector.
	newBrowser spawnHierarchy.

