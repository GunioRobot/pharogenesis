newFromStrike: fileName
	"Build an instance from the strike font file name. The '.strike' extension
	is optional."

	| strike startName raster16 |
	name _ fileName copyUpTo: $..	"assumes extension (if any) is '.strike'".
	strike _ FileStream oldFileNamed: name, '.strike.'.
	strike binary.
	strike readOnly.
		"strip off direcory name if any"
	startName _ name size.
	[startName > 0 and: [((name at: startName) ~= $>) & ((name at: startName) ~= $])]]
		whileTrue: [startName _ startName - 1].
	name _ name copyFrom: startName+1 to: name size.

	type			_		strike nextWord16.		"type is ignored now -- simplest
												assumed.  Kept here to make
												writing and consistency more
												straightforward."
	minAscii		_		strike nextWord16.
	maxAscii		_		strike nextWord16.
	maxWidth		_		strike nextWord16.
	strikeLength	_		strike nextWord16.
	ascent			_		strike nextWord16.
	descent			_		strike nextWord16.
	"xOffset			_"		strike nextWord16. 	
	raster16			_		strike nextWord16.	
	superscript		_		ascent - descent // 3.	
	subscript		_		descent - ascent // 3.	
	emphasis		_		0.
	glyphs			_	Form extent: (raster16 * 16) @ (self height)  
							offset: 0@0.
		glyphs bits fromByteStream: strike.

	xTable _ (Array new: maxAscii + 3) atAllPut: 0.
	(minAscii + 1 to: maxAscii + 3) do:
		[:index | xTable at: index put: strike nextWord16].

	"Set up space character"
	((xTable at: (Space asciiValue + 2))  = 0 or:
			[(xTable at: (Space asciiValue + 2)) = (xTable at: (Space asciiValue + 1))])
		ifTrue:	[(Space asciiValue + 2) to: xTable size do:
					[:index | xTable at: index put: ((xTable at: index) + DefaultSpace)]].
	strike close.

	self setStopConditions 