open: aMessageSet name: aString 
	"Create a standard system view for the messageSet, aMessageSet, whose label is aString."
	| topView aListView aBrowserCodeView aTextView underPane y buttonsView winWidth |

	Smalltalk isMorphic ifTrue: [^ self openAsMorph: aMessageSet name: aString].

	winWidth _ 200.
	topView _ (StandardSystemView new) model: aMessageSet.
	topView label: aString.
	topView minimumSize: winWidth @ 120.
	topView borderWidth: 1.

	aListView _ PluggableListView on: aMessageSet
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	aListView  menuTitleSelector: #messageListSelectorTitle.
	aListView window: (0 @ 0 extent: winWidth @ 100).
	topView addSubView: aListView.

	aMessageSet  wantsAnnotationPane
		ifTrue:
			[aTextView _ PluggableTextView on: aMessageSet 
			text: #annotation accept: nil
			readSelection: nil menu: nil.
			aTextView window: (0 @ 0 extent: winWidth @ 24).
			topView addSubView: aTextView below: aListView.
			underPane _ aTextView.
			y _ 300 - 24.
			aTextView askBeforeDiscardingEdits: false]
		ifFalse:
			[underPane _ aListView.
			y _ 300].

	aMessageSet wantsOptionalButtons ifTrue:
		[buttonsView _ aMessageSet buildOptionalButtonsView.
		topView addSubView: buttonsView below: underPane.
		underPane _ buttonsView.
		y _ y - aMessageSet optionalButtonHeight].

	aBrowserCodeView _ PluggableTextView on: aMessageSet 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	aBrowserCodeView window: (0 @ 0 extent: winWidth @ y).
	topView addSubView: aBrowserCodeView below: underPane.
	topView setUpdatablePanesFrom: #(messageList).
	topView controller open