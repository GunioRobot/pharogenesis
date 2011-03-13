open: aMessageSet name: aString 
	"Create a standard system view for the messageSet, aMessageSet, whose label is aString."
	| topView aListView aBrowserCodeView |

	World ifNotNil: [^ self openAsMorph: aMessageSet name: aString].

	topView _ (StandardSystemView new) model: aMessageSet.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	topView borderWidth: 1.

	aListView _ PluggableListView on: aMessageSet
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	aListView window: (0 @ 0 extent: 180 @ 100).
	topView addSubView: aListView.

	aBrowserCodeView _ PluggableTextView on: aMessageSet 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	aBrowserCodeView window: (0 @ 0 extent: 180 @ 300).
	topView addSubView: aBrowserCodeView below: aListView.
	topView controller open