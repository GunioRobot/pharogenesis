nextChunkText
	"Deliver the next chunk as a Text.  Decode the following ]style[ chunk if present.  Position at start of next real chunk."
	| string runsRaw strm runs peek |
	"Read the plain text"
	string _ self nextChunk.
	
	"Test for ]style[ tag"
	peek _ self skipSeparatorsAndPeekNext.
	peek = $] ifFalse: [^ string asText].  "no tag"
	(self upTo: $[) = ']style' ifFalse: [^ string asText].  "different tag"

	"Read and decode the style chunk"
	runsRaw _ self nextChunk.	"style encoding"
	strm _ ReadStream on: runsRaw from: 1 to: runsRaw size.
	runs _ RunArray scanFrom: strm.

	^ Text basicNew setString: string setRunsChecking: runs.
