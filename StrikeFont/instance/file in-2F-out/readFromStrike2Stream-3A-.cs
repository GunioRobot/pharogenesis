readFromStrike2Stream: file 
	"Build an instance from the supplied binary stream on data in strike2 format"
	type _ file nextInt32.  type = 2 ifFalse: [file close. self error: 'not strike2 format'].
	minAscii _ file nextInt32.
	maxAscii _ file nextInt32.
	maxWidth _ file nextInt32.
	ascent _ file nextInt32.
	descent _ file nextInt32.
	pointSize _ file nextInt32.
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	emphasis _ file nextInt32.
	xTable _ (Array new: maxAscii + 3) atAllPut: 0.
	(minAscii + 1 to: maxAscii + 3) do:
		[:index | xTable at: index put: file nextInt32].
	glyphs _ Form new readFrom: file.

	"Set up space character"
	((xTable at: (Space asciiValue + 2))  = 0 or:
			[(xTable at: (Space asciiValue + 2)) = (xTable at: (Space asciiValue + 1))])
		ifTrue:	[(Space asciiValue + 2) to: xTable size do:
					[:index | xTable at: index put: ((xTable at: index) + DefaultSpace)]].
	characterToGlyphMap _ nil.