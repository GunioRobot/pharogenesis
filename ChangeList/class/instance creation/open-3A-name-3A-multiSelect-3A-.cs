open: aChangeList name: aString multiSelect: multiSelect
	"Create a standard system view for the messageSet, whose label is aString.
	The listView may be either single or multiple selection type"

	| topView aBrowserCodeView aListView underPane pHeight |
	Smalltalk isMorphic ifTrue: [^ self openAsMorph: aChangeList name: aString multiSelect: multiSelect].
	topView _ (StandardSystemView new) model: aChangeList.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	topView borderWidth: 1.
	Preferences optionalButtons
		ifTrue:
			[underPane _ aChangeList optionalButtonsView.
			underPane isNil
				ifTrue: [pHeight _ 100]
				ifFalse:
					[topView addSubView: underPane.
					pHeight _ 100 - aChangeList optionalButtonHeight]]
		ifFalse:
			[underPane _ nil.
			pHeight _ 100].
	aListView _ (multiSelect
					ifTrue: [PluggableListViewOfMany]
					ifFalse: [PluggableListView])
		on: aChangeList list: #list
		selected: #listIndex changeSelected: #toggleListIndex:
		menu: (aChangeList showsVersions ifTrue: [#versionsMenu:] ifFalse: [#changeListMenu:])
		keystroke: #messageListKey:from:.
	aListView window: (0 @ 0 extent: 180 @ pHeight).
	underPane isNil
		ifTrue: [topView addSubView: aListView]
		ifFalse: [topView addSubView: aListView below: underPane].
	aBrowserCodeView _ PluggableTextView on: aChangeList 
			text: #contents accept: #contents:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	aBrowserCodeView controller: ReadOnlyTextController new.
	aBrowserCodeView window: (0 @ 0 extent: 180 @ 300).
	topView addSubView: aBrowserCodeView below: aListView.
	topView controller open