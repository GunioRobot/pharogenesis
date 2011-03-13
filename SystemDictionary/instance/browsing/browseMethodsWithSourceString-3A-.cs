browseMethodsWithSourceString: aString
	"Smalltalk browseMethodsWithSourceString: 'SourceString' "
	"Launch a browser on all methods whose source code contains aString as a substring.  The search is case-sensitive. This takes a long time right now.  7/23/96 di"
	^ self browseMessageList: (self allMethodsWithSourceString: aString)
		name: 'Methods containing ' , aString printString