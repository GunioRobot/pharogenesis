testMultistringFallbackFont
	"self debug: #testMultistringFallbackFont"
	| text p style height width |
	[(TextStyle default fontArray at: JapaneseEnvironment leadingChar)
		ifNil: [^ self]]
		ifError: [:err :rcvr | ^ self].
	text := ((#(20983874 20983876 20983878 )
				collect: [:e | e asCharacter])
				as: String) asText.
	p := MultiNewParagraph new.
	style := TextStyle new leading: 0; newFontArray: {Preferences standardFlapFont}.
	p
		compose: text
		style: style
		from: 1
		in: (0 @ 0 corner: 100 @ 100).
	"See CompositionScanner>>setActualFont: &  
	CompositionScanner>>composeFrom:inRectangle:firstLine:leftSide:rightSide:"
	height := style defaultFont height + style leading.
	width := text
				inject: 0
				into: [:tally :next | tally
						+ (style defaultFont widthOf: next)].
	p adjustRightX.
	self assert: p extent = (width @ height).
	"Display getCanvas
		paragraph: p
		bounds: (10 @ 10 extent: 100 @ 100)
		color: Color black"