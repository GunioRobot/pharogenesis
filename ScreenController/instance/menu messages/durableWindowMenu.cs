durableWindowMenu 
	| aMenu selectionList labelList targetList i wordingList colorPattern |
	aMenu _ self windowMenu.
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
			(#(fastWindows changeWindowPolicy) includes: aSelection)
				ifFalse:
					[nil]
				ifTrue:
					[aSelection == #fastWindows
						ifFalse:
							[#staggerPolicyString]
						ifTrue:
							[#bitCachingString]]].
	^ Utilities windowMenuWithLabels: labelList colorPattern: colorPattern  targets: targetList selections: selectionList wordingSelectors: wordingList title: 'windows'

