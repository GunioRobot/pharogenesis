addToGlossary: myName as: myURL
	|aStream |
	"Add to a CR-delimited file of 'pageName' and 'URL' separated by
vertical bars '|'"
	aStream _ directory oldFileNamed: 'glossary'.
	aStream open.
	aStream setToEnd.
	aStream nextPutAll: myName,'|',myURL; cr.
	aStream close.


	