browseVersionsOf: aSelector 
	"Open a browser on versions of aSelector"
	| aClass |
	aClass := scriptedPlayer class whichClassIncludesSelector: aSelector.
	Utilities browseVersionsForClass: aClass selector: aSelector