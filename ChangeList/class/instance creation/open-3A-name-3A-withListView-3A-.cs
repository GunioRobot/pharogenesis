open: aChangeList name: aString withListView: aListView
	"Create a standard system view for the messageSet, whose label is aString.
	The listView supplied may be either single or multiple selection type"
	| topView codeView |
	topView _ StandardSystemView new.
	topView model: aChangeList.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	aListView model: aChangeList.
	aListView list: aChangeList list.
	aListView window: (0 @ 0 extent: 180 @ 100).
	aListView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	topView addSubView: aListView.
	codeView _ StringHolderView new.
	codeView model: aChangeList.
	codeView window: (0 @ 0 extent: 180 @ 300).
	codeView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	topView
		addSubView: codeView
		align: codeView viewport topLeft
		with: aListView viewport bottomLeft.
	topView controller open 