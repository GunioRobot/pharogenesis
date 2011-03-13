openSystemCatEditString: aString
	"Create a pluggable version of all the views for a Browser, including views and controllers.  The top list view is of the currently selected system class category--a single item list."
	| systemCategoryListView classListView messageCategoryListView messageListView browserCodeView topView switchView |

	World ifNotNil: [^ self openAsMorphSysCatEditing: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	systemCategoryListView _ PluggableListView on: self
		list: #systemCategorySingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #systemCategoryMenu:.
	systemCategoryListView window: (0 @ 0 extent: 200 @ 12).
	topView addSubView: systemCategoryListView.

	classListView _ PluggableListView on: self
		list: #classList
		selected: #classListIndex
		changeSelected: #classListIndex:
		menu: #classListMenu:.
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
	messageListView window: (0 @ 0 extent: 67 @ 70).
	topView addSubView: messageListView toRightOf: messageCategoryListView.

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@(110-12)).
	topView addSubView: browserCodeView below: switchView.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView
