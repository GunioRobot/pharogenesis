getPageNumber
	"Answer the current page number of my book"

	| aBook |
	^ (aBook _ self bookEmbodied) pageNumberOf: aBook currentPage