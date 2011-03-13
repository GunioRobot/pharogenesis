openOnClassWithEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| classListView messageCategoryListView messageListView browserCodeView topView switchView annotationPane underPane y optionalButtonsView |

	Smalltalk isMorphic ifTrue: [^ self openAsMorphClassEditing: aString].

	topView := (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	classListView := PluggableListView on: self
		list: #classListSingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #classListMenu:shifted:
		keystroke: #classListKey:from:.
	classListView window: (0 @ 0 extent: 100 @ 12).
	topView addSubView: classListView.

	messageCategoryListView := PluggableListView on: self
		list: #messageCategoryList
		selected: #messageCategoryListIndex
		changeSelected: #messageCategoryListIndex:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 100 @ 70).
	topView addSubView: messageCategoryListView below: classListView.

	messageListView := PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView menuTitleSelector: #messageListSelectorTitle.
	messageListView window: (0 @ 0 extent: 100 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	switchView := self buildInstanceClassSwitchView.
	switchView borderWidth: 1.
	switchView 
		window: switchView window 
		viewport: (classListView viewport topRight 
					corner: messageListView viewport topRight).
	topView addSubView: switchView toRightOf: classListView.

	 self wantsAnnotationPane
		ifTrue:
			[annotationPane := PluggableTextView on: self
				text: #annotation accept: nil
				readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: messageCategoryListView.
			underPane := annotationPane.
			y := (200-12-70) - self optionalAnnotationHeight]
		ifFalse:
			[underPane := messageCategoryListView.
			y := (200-12-70)].

	self wantsOptionalButtons ifTrue:
		[optionalButtonsView := self buildOptionalButtonsView.
		optionalButtonsView borderWidth: 1.
		topView addSubView: optionalButtonsView below: underPane.
		underPane := optionalButtonsView.
		y := y - self optionalButtonHeight].

	browserCodeView := MvcTextEditor default on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@y).
	topView addSubView: browserCodeView below: underPane.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].

	topView setUpdatablePanesFrom: #(messageCategoryList messageList).
	^ topView