downloadStateIn: aScamper
	"download the image"
	| doc |
	doc _ url retrieveContents.
	downloadQueue nextPut: doc.

