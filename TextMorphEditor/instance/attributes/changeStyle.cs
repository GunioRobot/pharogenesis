changeStyle
	"Let user change styles for the current text pane."
	| aList reply style theStyle menuList |
	self flag: #arNote. "Move this up once we get rid of MVC"
	aList := StrikeFont actualFamilyNames.
	theStyle := paragraph textStyle.
	menuList := aList collect:[:styleName|
		"Hack! use defaultFont for comparison - we have no name that we could use for compare and the style changes with alignment so they're no longer equal."
		(TextConstants at: styleName) defaultFont == theStyle defaultFont
			ifTrue:['<on>', styleName]
			ifFalse:['<off>',styleName]].
	theStyle = TextStyle default
		ifTrue:[menuList addFirst: '<on>DefaultTextStyle']
		ifFalse:[menuList addFirst: '<off>DefaultTextStyle'].
	aList addFirst: 'DefaultTextStyle'.
	reply := UIManager default chooseFrom: menuList  values: aList lines: #(1).
	reply ifNotNil:
		[(style := TextStyle named: reply) ifNil: [Beeper beep. ^ true].
		paragraph textStyle: style copy.
		paragraph composeAll.
		self recomputeSelection.
		].
	^ true