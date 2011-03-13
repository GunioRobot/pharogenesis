openMessageCatEditString: aString
	"Create a pluggable version of the views for a Browser that just shows one message category."
	| messageCategoryListView messageListView browserCodeView topView |

	World ifNotNil: [^ self openAsMorphMsgCatEditing: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	messageCategoryListView _ PluggableListView on: self
		list: #messageCatListSingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #messageCategoryMenu:.
	messageCategoryListView window: (0 @ 0 extent: 200 @ 12).
	topView addSubView: messageCategoryListView.

	messageListView _ PluggableListView on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	messageListView window: (0 @ 0 extent: 200 @ 70).
	topView addSubView: messageListView below: messageCategoryListView.

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@(200-12-70)).
	topView addSubView: browserCodeView below: messageListView.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView
