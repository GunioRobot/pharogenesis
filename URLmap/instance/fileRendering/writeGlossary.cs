writeGlossary
	"Write out the pages dictionary as a CR-delimited file of pagename
and URL"
	|aStream |
	aStream _ directory oldFileNamed: 'glossary'.
	aStream open.
	pages keys asSortedCollection do: [:each |
		aStream nextPutAll: (pages at: each) name,'|',(pages at:
each) coreID; cr.].
	aStream close.


	