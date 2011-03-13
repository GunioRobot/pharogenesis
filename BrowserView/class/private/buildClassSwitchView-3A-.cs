buildClassSwitchView: aBrowser

	| aSwitchView |
	aSwitchView _ SwitchView new.
	aSwitchView model: aBrowser.
	aSwitchView controller: LockedSwitchController new.
	aSwitchView selector: #classMessagesIndicated.
	aSwitchView controller selector: #indicateClassMessages.
	aSwitchView window: (0 @ 0 extent: 25 @ 8).
	aSwitchView label: 'class' asParagraph.
	^aSwitchView