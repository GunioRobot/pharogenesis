changeTextFont
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.
	If there is no selection, or the selection is empty, apply it to the whole morph."
	| curFont newFont attr startIndex stopIndex |
	startIndex _ self startIndex.
	stopIndex := self stopIndex-1 min: paragraph text size.
	curFont _ (paragraph text fontAt: startIndex withStyle: paragraph textStyle).
	newFont _ StrikeFont fromUser: curFont allowKeyboard: false.
	newFont ifNil:[^self].
	attr _ TextFontReference toFont: newFont.
	stopIndex >= startIndex
		ifTrue: [ paragraph text addAttribute: attr from: startIndex to: stopIndex ]
		ifFalse: [ paragraph text addAttribute: attr from: 1 to: paragraph text size. ].

	paragraph composeAll.
	self recomputeInterval.
