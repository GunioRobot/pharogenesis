changeStyle
	"Let user change styles for the current text pane."
	| aList reply style theStyle menuList startIndex stopIndex |
	self flag: #arNote. "Move this up once we get rid of MVC"
	startIndex _ self startIndex.
	stopIndex := self stopIndex-1 min: paragraph text size.
	aList _ StrikeFont actualFamilyNames.
	theStyle _ paragraph textStyle.
	menuList _ aList collect:[:styleName|
		"Hack! use defaultFont for comparison - we have no name that we could use for compare and the style changes with alignment so they're no longer equal."
		(TextConstants at: styleName) defaultFont == theStyle defaultFont
			ifTrue:['<on>', styleName]
			ifFalse:['<off>',styleName]].
	theStyle = TextStyle default
		ifTrue:[menuList addFirst: '<on>DefaultTextStyle']
		ifFalse:[menuList addFirst: '<off>DefaultTextStyle'].
	aList addFirst: 'DefaultTextStyle'.
	reply _ (SelectionMenu labelList: menuList lines: #(1) selections: aList) startUpWithCaption: nil at: ActiveHand position allowKeyboard: false.
	reply ifNotNil:
		[(style _ TextStyle named: reply) ifNil: [Beeper beep. ^ true].
		paragraph textStyle: style copy.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	morph selectFrom: startIndex to: stopIndex.
	^ true