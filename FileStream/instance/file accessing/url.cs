url
	"Convert my path into a file:// type url.  Use slash instead of the local delimiter (:), and convert odd characters to %32 notation."

	"If / is not the file system delimiter, encode / before converting."
	| list |
	list _ self directory pathParts.
	^ String streamContents: [:strm |
		strm nextPutAll: 'file:/'.
		list do: [:each | strm nextPut: $/; nextPutAll: each encodeForHTTP].
		strm nextPut: $/; nextPutAll: self localName encodeForHTTP]