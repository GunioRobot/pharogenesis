startPage: newPage
	"fill in the contents of the user's personal start page"
	| file |
	FileDirectory default deleteFileNamed: 'StartPage.html'.
	file _ FileStream fileNamed: 'StartPage.html'.
	file ifNil: [ self error: 'could not save file' ].
	file nextPutAll: newPage asString.
	file close.
	
	self changed: #startPage.
	^true