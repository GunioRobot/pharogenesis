testParagraphFallback
	"self debug: #testParagraphFallback"
	| text p style height width e expect |
	e := (Character value: 257) asString.
	text := ('test' , e , e , e , e , 'test') asText.
	expect := 'test????test'.
	p := MultiNewParagraph new.
	style := TextStyle default.
	p
		compose: text
		style: style
		from: 1
		in: (0 @ 0 corner: 100 @ 100).
	"See CompositionScanner>>setActualFont: &  
	CompositionScanner>>composeFrom:inRectangle:firstLine:leftSide:rightSide:"
	height := style defaultFont height + style leading.
	width := expect
				inject: 0
				into: [:tally :next | tally
						+ (style defaultFont widthOf: next)].
	p adjustRightX.
	self assert: p extent = (width @ height).
	"Display getCanvas
		paragraph: p
		bounds: (10 @ 10 extent: 100 @ 100)
		color: Color black"