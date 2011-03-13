open: aChangeList name: aString multiSelect: multiSelect
	"Create a standard system view for the messageSet, whose label is aString.
	The listView may be either single or multiple selection type"
	| topView aBrowserCodeView aListView |

	World ifNotNil: [^ self openAsMorph: aChangeList name: aString multiSelect: multiSelect].

	topView _ (StandardSystemView new) model: aChangeList.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	topView borderWidth: 1.

	aListView _ (multiSelect ifTrue: [PluggableListViewOfMany]
							ifFalse: [PluggableListView])
		on: aChangeList list: #list
		selected: #listIndex changeSelected: #toggleListIndex:
		menu: #changeListMenu:
		keystroke: #messageListKey:from:.
	aListView window: (0 @ 0 extent: 180 @ 100).
	topView addSubView: aListView.

	aBrowserCodeView _ PluggableTextView on: aChangeList 
			text: #contents accept: #contents:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	aBrowserCodeView controller: ReadOnlyTextController new.
	aBrowserCodeView window: (0 @ 0 extent: 180 @ 300).
	topView addSubView: aBrowserCodeView below: aListView.
	topView controller open