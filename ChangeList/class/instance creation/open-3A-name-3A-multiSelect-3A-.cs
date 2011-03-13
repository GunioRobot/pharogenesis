open: aChangeList name: aString multiSelect: multiSelect
	"Create a standard system view for the messageSet, whose label is aString.
	The listView may be either single or multiple selection type"

	| topView listHeight annoHeight optButtonHeight codeHeight aListView underPane annotationPane buttonsView aBrowserCodeView |
	Smalltalk isMorphic
		ifTrue: [^ self openAsMorph: aChangeList name: aString multiSelect: multiSelect].

	listHeight _ 70.
	annoHeight _ 10.
	optButtonHeight _ aChangeList optionalButtonHeight.
	codeHeight _ 110.

	topView _ (StandardSystemView new)
		model: aChangeList;
		label: aString;
		minimumSize: 200 @ 120;
		borderWidth: 1.

	aListView _ (multiSelect
			ifTrue: [PluggableListViewOfMany]
			ifFalse: [PluggableListView])
		on: aChangeList
		list: #list
		selected: #listIndex
		changeSelected: #toggleListIndex:
		menu: (aChangeList showsVersions
			ifTrue: [#versionsMenu:]
			ifFalse: [#changeListMenu:])
		keystroke: #changeListKey:from:.
	aListView window: (0 @ 0 extent: 200 @ listHeight).
	topView addSubView: aListView.

	underPane _ aListView.
	aChangeList wantsAnnotationPane
		ifTrue:
			[annotationPane _ PluggableTextView
				on: aChangeList
				text: #annotation
				accept: nil
				readSelection: nil
				menu: nil.
			annotationPane window: (0 @ 0 extent: 200 @ 10).
			topView addSubView: annotationPane below: underPane.
			underPane _ annotationPane.
			codeHeight _ codeHeight - annoHeight].

	aChangeList wantsOptionalButtons
		ifTrue:
			[buttonsView _ aChangeList optionalButtonsView.
			buttonsView borderWidth: 1.
			topView addSubView: buttonsView below: underPane.
			underPane _ buttonsView.
			codeHeight _ codeHeight - optButtonHeight].

	aBrowserCodeView _ PluggableTextView
			on: aChangeList
			text: #contents
			accept: #contents:
			readSelection: #contentsSelection
			menu: #codePaneMenu:shifted:.
	aBrowserCodeView
			controller: ReadOnlyTextController new;
			window: (0 @ 0 extent: 200 @ codeHeight).
	topView addSubView: aBrowserCodeView below: underPane.

	topView controller open.