windowFromMenu: aMenu target: aTarget title: aTitle colorPattern: aColorPattern
	| labelList targetList selectionList i |
	selectionList _ aMenu selections.
	labelList _ (1 to: selectionList size) collect:
		[:ind | aMenu labelString lineNumber: ind].
	targetList _  (1 to: selectionList size) collect: [:ind | aTarget].

	(i _ labelList indexOf: 'keep this menu up') > 0 ifTrue:
		[selectionList _ selectionList copyReplaceFrom: i to: i with: Array new.
		labelList _ labelList copyReplaceFrom: i to: i with: Array new.
		targetList _ targetList copyReplaceFrom: i to: i with: Array new].

	self windowMenuWithLabels:  labelList colorPattern: aColorPattern targets: targetList selections: selectionList title: aTitle