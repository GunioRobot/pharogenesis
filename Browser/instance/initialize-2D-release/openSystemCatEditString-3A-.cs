openSystemCatEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers.  The top list view is of the currently selected system class category--a single item list."
	| systemCategoryListView classListView messageCategoryListView messageListView browserCodeView topView switchView y annotationPane underPane optionalButtonsView |

	Smalltalk isMorphic ifTrue: [^ self openAsMorphSysCatEditing: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	systemCategoryListView _ PluggableListView on: self
		list: #systemCategorySingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #systemCatSingletonMenu:
		keystroke: #systemCatSingletonKey:from:.
	systemCategoryListView window: (0 @ 0 extent: 200 @ 12).
	topView addSubView: systemCategoryListView.

	classListView _ PluggableListView on: self
		list: #classList
		selected: #classListIndex
		changeSelected: #classListIndex:
		menu: #classListMenu:shifted:
		keystroke: #classListKey:from:.
	classListView window: (0 @ 0 extent: 67 @ 62).
	topView addSubView: classListView below: systemCategoryListView.

	messageCategoryListView _ PluggableListView on: self
		list: #messageCategoryList
		selected: #messageCategoryListIndex
		changeSelected: #messageCategoryListIndex:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 66 @ 70).
	topView addSubView: messageCategoryListView toRightOf: classListView.

	switchView _ self buildInstanceClassSwitchView.
	switchView 
		window: switchView window 
		viewport: (classListView viewport bottomLeft 
					corner: messageCategoryListView viewport bottomLeft).
	switchView borderWidth: 1.
	topView addSubView: switchView below: classListView.

	messageListView _ PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView menuTitleSelector: #messageListSelectorTitle.
	messageListView window: (0 @ 0 extent: 67 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	 self wantsAnnotationPane
		ifTrue:
			[annotationPane _ PluggableTextView on: self
				text: #annotation accept: nil
				readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: switchView.
			y _ 110 - 12 - self optionalAnnotationHeight.
			underPane _ annotationPane]
		ifFalse:
			[y _ 110 - 12.
			underPane _ switchView].

	self wantsOptionalButtons ifTrue:
		[optionalButtonsView _ self buildOptionalButtonsView.
		optionalButtonsView borderWidth: 1.
		topView addSubView: optionalButtonsView below: underPane.
		underPane _ optionalButtonsView.
		y _ y - self optionalButtonHeight].

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@y).
	topView addSubView: browserCodeView below: underPane.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	topView setUpdatablePanesFrom: #(classList messageCategoryList messageList).
	^ topView