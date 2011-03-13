openEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| systemCategoryListView classListView 
	messageCategoryListView messageListView browserCodeView topView switchView |

	World ifNotNil: [^ self openAsMorphEditing: aString].
	Sensor leftShiftDown ifTrue: [^ self openAsMorphEditing: aString "testing"].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	systemCategoryListView _ PluggableListView on: self
		list: #systemCategoryList
		selected: #systemCategoryListIndex
		changeSelected: #systemCategoryListIndex:
		menu: #systemCategoryMenu:.
	systemCategoryListView window: (0 @ 0 extent: 50 @ 70).
	topView addSubView: systemCategoryListView.

	classListView _ PluggableListView on: self
		list: #classList
		selected: #classListIndex
		changeSelected: #classListIndex:
		menu: #classListMenu:.
	classListView window: (0 @ 0 extent: 50 @ 62).
	topView addSubView: classListView toRightOf: systemCategoryListView.

	switchView _ self buildInstanceClassSwitchView.
	switchView borderWidth: 1.
	topView addSubView: switchView below: classListView.

	messageCategoryListView _ PluggableListView on: self
		list: #messageCategoryList
		selected: #messageCategoryListIndex
		changeSelected: #messageCategoryListIndex:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 50 @ 70).
	topView addSubView: messageCategoryListView toRightOf: classListView.

	messageListView _ PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView window: (0 @ 0 extent: 50 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@110).
	topView addSubView: browserCodeView below: systemCategoryListView.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView
