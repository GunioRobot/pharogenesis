httpGetNoError: url args: args accept: mimeType
	"Return the exact contents of a web file.  Do better error checking.  Asks for the given MIME type.  To fetch raw data, you can use the MIMI type 'application/octet-stream'.  If mimeType is nil, use 'text/html'.  The parsed header is saved. Use a proxy server if one has been registered."

"Edited to remove a lineFeed from the source 4/4/99 - di"

	| document data |
	document _ self httpGetDocument: url  args: args  accept: mimeType.
	(document isKindOf: String) ifTrue: [
		"strings indicate errors"
		^ document ].
	data _ document content.
	(data beginsWith: '<HTML><HEAD>' , (String with: Character linefeed) , '<TITLE>4')
		ifTrue: ["an error message  404 File not found"
				^ data copyFrom: 21 to: data size-16].	

	^ (RWBinaryOrTextStream with: data) reset
