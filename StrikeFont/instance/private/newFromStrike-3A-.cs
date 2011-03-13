newFromStrike: fileName
	"Build an instance from the strike font file name. The '.strike' extension
	is optional."

	| strike startName |
	name _ fileName copyUpTo: $..	"assumes extension (if any) is '.strike'".
	strike _ FileStream oldFileNamed: name, '.strike.'.
	strike binary.
	strike readOnly.
		"strip off direcory name if any"
	startName _ name size.
	[startName > 0 and: [((name at: startName) ~= $>) & ((name at: startName) ~= $])]]
		whileTrue: [startName _ startName - 1].
	name _ name copyFrom: startName+1 to: name size.

	type			_		strike nextWord.		"type is ignored now -- simplest
												assumed.  Kept here to make
												writing and consistency more
												straightforward."
	minAscii		_		strike nextWord.
	maxAscii		_		strike nextWord.
	maxWidth		_		strike nextWord.
	strikeLength	_		strike nextWord.
	ascent			_		strike nextWord.
	descent			_		strike nextWord.
	xOffset			_		strike nextWord. 	
	raster			_		strike nextWord.	
	superscript		_		ascent - descent // 3.	
	subscript		_		descent - ascent // 3.	
	emphasis		_		0.
self halt.  "This needs to be fixed up..."
	glyphs			_
		Form new setExtent: (raster * 16) @ (self height)  
				   offset: 0@0
				   bits: ((Bitmap new: raster * self height) fromByteStream: strike).

	xTable _ (Array new: maxAscii + 3) atAllPut: 0.
	(minAscii + 1 to: maxAscii + 3) do:
		[:index | xTable at: index put: strike nextWord].

	"Set up space character"
	((xTable at: (Space asciiValue + 2))  = 0 or:
			[(xTable at: (Space asciiValue + 2)) = (xTable at: (Space asciiValue + 1))])
		ifTrue:	[(Space asciiValue + 2) to: xTable size do:
					[:index | xTable at: index put: ((xTable at: index) + DefaultSpace)]].
	strike close.

	"This has to do with scanning characters, not with the font"
	stopConditions _ Array new: 258.
	stopConditions atAllPut: nil.
	1 to: (minAscii - 1) do:
		[:index | stopConditions at: index put: #characterNotInFont].
	(maxAscii + 3) to: stopConditions size do:
		[:index | stopConditions at: index put: #characterNotInFont]