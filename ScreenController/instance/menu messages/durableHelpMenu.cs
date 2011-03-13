durableHelpMenu 
	| aMenu selectionList labelList targetList i wordingList colorPattern |
	aMenu := self helpMenu.
	selectionList := aMenu selections.
	labelList := (1 to: selectionList size) collect:
		[:ind | aMenu labelString lineNumber: ind].
	targetList :=  (1 to: selectionList size) collect: [:ind | self].

	(i := labelList indexOf: 'keep this menu up') > 0 ifTrue:
		[selectionList := selectionList copyReplaceFrom: i to: i with: Array new.
		labelList := labelList copyReplaceFrom: i to: i with: Array new.
		targetList := targetList copyReplaceFrom: i to: i with: Array new].

	colorPattern := #(lightRed lightGreen lightBlue lightYellow lightGray lightCyan lightMagenta lightOrange).

	wordingList := selectionList collect:
		[:aSelection |
			(aSelection == #soundOnOrOff) ifTrue: [#soundEnablingString] ifFalse: [nil]].
	^ Utilities windowMenuWithLabels: labelList colorPattern: colorPattern  targets: targetList selections: selectionList wordingSelectors: wordingList title: 'Help'

