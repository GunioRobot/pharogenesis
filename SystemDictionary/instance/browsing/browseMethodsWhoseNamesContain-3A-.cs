browseMethodsWhoseNamesContain: aString
	"Launch a browser on all methods whose names contain the given string; case-insensitive.  This takes a long time right now.  1/16/96 sw"

	| aList |
	aList _ Symbol selectorsContaining: aString.
	aList size > 0 ifTrue: 
		[self browseAllImplementorsOfList: aList asSortedCollection title: 'Methods whose names contain ''', aString, '''']