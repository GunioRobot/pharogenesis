openEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	"PackageBrowser openBrowser"

	| packageListView systemCategoryListView classListView messageCategoryListView
	  messageListView browserCodeView topView switchView annotationPane underPane y optionalButtonsView |

	self couldOpenInMorphic ifTrue: [^ self openAsMorphEditing: aString].

	topView := StandardSystemView new model: self.
	topView borderWidth: 1.  "label and minSize taken care of by caller"

	packageListView := PluggableListView on: self
		list: #packageList
		selected: #packageListIndex
		changeSelected: #packageListIndex:
		menu: #packageMenu:.
	packageListView window: (0 @ 0 extent: 20 @ 70).
	topView addSubView: packageListView.

	systemCategoryListView := PluggableListView on: self
		list: #systemCategoryList
		selected: #systemCategoryListIndex
		changeSelected: #systemCategoryListIndex:
		menu: #systemCategoryMenu:.
	systemCategoryListView window: (20 @ 0 extent: 30 @ 70).
	topView addSubView: systemCategoryListView.

	classListView := PluggableListView on: self
		list: #classList
		selected: #classListIndex
		changeSelected: #classListIndex:
		menu: #classListMenu:shifted:.
	classListView window: (0 @ 0 extent: 50 @ 62).
	topView addSubView: classListView toRightOf: systemCategoryListView.

	switchView := self buildInstanceClassSwitchView.
	switchView borderWidth: 1.
	topView addSubView: switchView below: classListView.

	messageCategoryListView := PluggableListView on: self
		list: #messageCategoryList
		selected: #messageCategoryListIndex
		changeSelected: #messageCategoryListIndex:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 50 @ 70).
	topView addSubView: messageCategoryListView toRightOf: classListView.

	messageListView := PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView window: (0 @ 0 extent: 50 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	self wantsAnnotationPane
		ifTrue:
			[annotationPane _ PluggableTextView on: self
				text: #annotation accept: nil
				readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: packageListView.
			underPane _ annotationPane.
			y _ 110 - self optionalAnnotationHeight]
		ifFalse:
			[underPane _ packageListView.
			y _ 110].

	self wantsOptionalButtons ifTrue:
		[optionalButtonsView _ self buildOptionalButtonsView.
		optionalButtonsView borderWidth: 1.
		topView addSubView: optionalButtonsView below: underPane.
		underPane _ optionalButtonsView.
		y _ y - self optionalButtonHeight].

	browserCodeView := MvcTextEditor default on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@y).
	topView addSubView: browserCodeView below: underPane.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView