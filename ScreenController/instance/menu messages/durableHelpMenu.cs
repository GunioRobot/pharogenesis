durableHelpMenu 
	| aMenu selectionList labelList targetList i wordingList colorPattern |
	aMenu _ self helpMenu.
	selectionList _ aMenu selections.
	labelList _ (1 to: selectionList size) collect:
		[:ind | aMenu labelString lineNumber: ind].
	targetList _  (1 to: selectionList size) collect: [:ind | self].

	(i _ labelList indexOf: 'keep this menu up') > 0 ifTrue:
		[selectionList _ selectionList copyReplaceFrom: i to: i with: Array new.
		labelList _ labelList copyReplaceFrom: i to: i with: Array new.
		targetList _ targetList copyReplaceFrom: i to: i with: Array new].

	colorPattern _ #(lightRed lightGreen lightBlue lightYellow lightGray lightCyan lightMagenta lightOrange).

	wordingList _ selectionList collect:
		[:aSelection |
			(aSelection == #soundOnOrOff) ifTrue: [#soundEnablingString] ifFalse: [nil]].
	^ Utilities windowMenuWithLabels: labelList colorPattern: colorPattern  targets: targetList selections: selectionList wordingSelectors: wordingList title: 'Help'

