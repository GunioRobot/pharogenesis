browseMethodFull: aSelector
	"Open a traditional browser on aSelector, in whatever class implements aSelector"

	| aClass |
	aClass _ scriptedPlayer class classThatUnderstands: aSelector.
	Browser fullOnClass: aClass selector: aSelector

