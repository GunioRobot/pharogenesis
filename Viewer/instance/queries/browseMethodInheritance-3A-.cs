browseMethodInheritance: aSelector 
	"Open an inheritance browser on aSelector"
	| aClass |
	aClass _ scriptedPlayer class whichClassIncludesSelector: aSelector.
	self systemNavigation methodHierarchyBrowserForClass: aClass selector: aSelector