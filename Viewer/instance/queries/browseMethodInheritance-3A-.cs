browseMethodInheritance: aSelector
	"Open an inheritance browser on aSelector"

	| aClass |
	aClass _ scriptedPlayer class classThatUnderstands: aSelector.
	Utilities methodHierarchyBrowserForClass: aClass selector: aSelector

