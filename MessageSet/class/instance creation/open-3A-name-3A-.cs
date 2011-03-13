open: aMessageSet name: aString 
	"Create a standard system view for the messageSet, aMessageSet, whose label is aString."

	| topView aListView aBrowserCodeView |
	topView _ StandardSystemView new.
	topView model: aMessageSet.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	aListView _ MessageListView new.
	aListView model: aMessageSet.
	aListView list: aMessageSet messageList.
	aListView window: (0 @ 0 extent: 180 @ 100).
	aListView
		borderWidthLeft: 2
		right: 2
		top: 2
		bottom: 0.
	topView addSubView: aListView.
	aBrowserCodeView _ BrowserCodeView new.
	aBrowserCodeView model: aMessageSet.
	aBrowserCodeView window: (0 @ 0 extent: 180 @ 300).
	aBrowserCodeView
		borderWidthLeft: 2
		right: 2
		top: 2
		bottom: 2.
	topView
		addSubView: aBrowserCodeView
		align: aBrowserCodeView viewport topLeft
		with: aListView viewport bottomLeft.
	topView controller open