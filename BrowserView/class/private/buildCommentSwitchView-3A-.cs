buildCommentSwitchView: aBrowser

	| aSwitchView |
	aSwitchView _ SwitchView new.
	aSwitchView model: aBrowser.
	aSwitchView controller: LockedSwitchController new.
	aSwitchView borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
	aSwitchView selector: #classCommentIndicated.
	aSwitchView controller selector: #editComment.
	aSwitchView window: (0 @ 0 extent: 10 @ 8).
	aSwitchView label: '?' asText allBold asParagraph.
	^aSwitchView