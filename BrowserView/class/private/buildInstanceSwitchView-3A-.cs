buildInstanceSwitchView: aBrowser

	| aSwitchView |
	aSwitchView _ SwitchView new.
	aSwitchView model: aBrowser.
	aSwitchView controller: LockedSwitchController new.
	aSwitchView borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
	aSwitchView selector: #instanceMessagesIndicated.
	aSwitchView controller selector: #indicateInstanceMessages.
	aSwitchView window: (0 @ 0 extent: 25 @ 8).
	aSwitchView label: 'instance' asParagraph.
	^aSwitchView