httpShowChunk: url
	"From a Swiki server, get a text chunk in the changes file.  Show its text in a window with style.  Vertical bar separates class and selector.  BE SURE TO USE ; instead of : in selectors!"
	"	HTTPSocket httpShowChunk: 'http://206.16.12.145:80/OurOwnArea.chunk.Socket|Comment'	 "
	"	HTTPSocket httpShowChunk: 'http://206.16.12.145:80/OurOwnArea.chunk.Point|class|x;y;'	"

	| doc text |
	doc _ (self httpGet: url accept: 'application/octet-stream').
"	doc size = 0 ifTrue: [doc _ 'The server does not seem to be responding']."
	doc class == String ifTrue: [text _ doc] ifFalse: [text _ doc nextChunkText].
	StringHolderView
		open: (StringHolder new contents: text)
		label: url.
