openOnClassWithEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| classListView messageCategoryListView messageListView browserCodeView topView switchView |

	World ifNotNil: [^ self openAsMorphClassEditing: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	classListView _ PluggableListView on: self
		list: #classListSingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #classListMenu:.
	classListView window: (0 @ 0 extent: 100 @ 12).
	topView addSubView: classListView.

	messageCategoryListView _ PluggableListView on: self
		list: #messageCategoryList
		selected: #messageCategoryListIndex
		changeSelected: #messageCategoryListIndex:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 100 @ 70).
	topView addSubView: messageCategoryListView below: classListView.

	messageListView _ PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView window: (0 @ 0 extent: 100 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	switchView _ self buildInstanceClassSwitchView.
	switchView borderWidth: 1.
	switchView 
		window: switchView window 
		viewport: (classListView viewport topRight 
					corner: messageListView viewport topRight).
	topView addSubView: switchView toRightOf: classListView.

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@(200-12-70)).
	topView addSubView: browserCodeView below: messageCategoryListView.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView
