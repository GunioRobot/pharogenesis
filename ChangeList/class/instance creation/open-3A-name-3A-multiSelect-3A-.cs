open: aChangeList name: aString multiSelect: multiSelect
	"Create a standard system view for the messageSet, whose label is aString.
	The listView may be either single or multiple selection type"

	| topView listHeight annoHeight optButtonHeight codeHeight aListView underPane annotationPane buttonsView aBrowserCodeView |
	Smalltalk isMorphic
		ifTrue: [^ self openAsMorph: aChangeList name: aString multiSelect: multiSelect].

	listHeight := 70.
	annoHeight := 10.
	optButtonHeight := aChangeList optionalButtonHeight.
	codeHeight := 110.

	topView := (StandardSystemView new)
		model: aChangeList;
		label: aString;
		minimumSize: 200 @ 120;
		borderWidth: 1.

	aListView := (multiSelect
			ifTrue: [PluggableListViewOfMany
						on: aChangeList
						list: #list
						primarySelection: #listIndex
						changePrimarySelection: #toggleListIndex:
						listSelection: #listSelectionAt:
						changeListSelection: #listSelectionAt:put:
						menu: (aChangeList showsVersions
								ifTrue: [#versionsMenu:]
								ifFalse: [#changeListMenu:])]
			ifFalse: [PluggableListView
						on: aChangeList
						list: #list
						selected: #listIndex
						changeSelected: #toggleListIndex:
						menu: (aChangeList showsVersions
								ifTrue: [#versionsMenu:]
								ifFalse: [#changeListMenu:])]).
	aListView window: (0 @ 0 extent: 200 @ listHeight).
	topView addSubView: aListView.

	underPane := aListView.
	aChangeList wantsAnnotationPane
		ifTrue:
			[annotationPane := PluggableTextView
				on: aChangeList
				text: #annotation
				accept: nil
				readSelection: nil
				menu: nil.
			annotationPane window: (0 @ 0 extent: 200 @ 10).
			topView addSubView: annotationPane below: underPane.
			underPane := annotationPane.
			codeHeight := codeHeight - annoHeight].

	aChangeList wantsOptionalButtons
		ifTrue:
			[buttonsView := aChangeList optionalButtonsView.
			buttonsView borderWidth: 1.
			topView addSubView: buttonsView below: underPane.
			underPane := buttonsView.
			codeHeight := codeHeight - optButtonHeight].

	aBrowserCodeView := PluggableTextView
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