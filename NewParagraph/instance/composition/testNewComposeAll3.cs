testNewComposeAll3
	| newResult |
	newResult := TextComposer new
		multiComposeLinesFrom: firstCharacterIndex 
		to: text size 
		delta: 0
		into: OrderedCollection new 
		priorLines: Array new 
		atY: container top
		textStyle: textStyle 
		text: text 
		container: (0@0 extent: 31@60)
		wantsColumnBreaks: false.
	^{newResult. {lines. maxRightX}}
