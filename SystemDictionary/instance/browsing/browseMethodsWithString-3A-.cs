browseMethodsWithString: aString
	"Launch a browser on all methods which contain string literals that have aString as a substring.  The search is case-sensitive. This takes a long time right now.  2/1/96 sw"

	| aList |
	aList _ self allMethodsWithString: aString.
	aList size > 0 ifTrue: 
		[Cursor normal show.
		self browseMessageList: aList  name: 'Methods with string ''', aString, '''']