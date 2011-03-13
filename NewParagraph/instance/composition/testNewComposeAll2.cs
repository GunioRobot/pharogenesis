testNewComposeAll2
	| newResult |
	newResult := TextComposer new
		composeLinesFrom: firstCharacterIndex 
		to: text size 
		delta: 0
		into: OrderedCollection new 
		priorLines: Array new 
		atY: container top
		textStyle: textStyle 
		text: text 
		container: container
		wantsColumnBreaks: false.
	^{newResult. {lines. maxRightX}}
