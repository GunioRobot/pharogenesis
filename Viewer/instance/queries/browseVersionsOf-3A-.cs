browseVersionsOf: aSelector 
	"Open a browser on versions of aSelector"
	| aClass |
	aClass _ scriptedPlayer class whichClassIncludesSelector: aSelector.
	Utilities browseVersionsForClass: aClass selector: aSelector