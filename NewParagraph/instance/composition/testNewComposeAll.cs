testNewComposeAll
	| newResult |
	self 
		OLDcomposeLinesFrom: firstCharacterIndex 
		to: text size 
		delta: 0
		into: OrderedCollection new 
		priorLines: Array new 
		atY: container top.
	newResult _ TextComposer new
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
	newResult first with: lines do: [ :e1 :e2 |
		e1 longPrintString = e2 longPrintString ifFalse: [self halt].
	].
	newResult second = maxRightX ifFalse: [self halt].
	^{newResult. {lines. maxRightX}}
