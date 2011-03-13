openMessageEditString: aString
	"Create a pluggable version of the views for a Browser that just shows one message."
	| messageListView browserCodeView topView |

	World ifNotNil: [^ self openAsMorphMessageEditing: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
		"label and minSize taken care of by caller"

	messageListView _ PluggableListView on: self
		list: #messageListSingleton
		selected: #indexIsOne 
		changeSelected: #indexIsOne:
		menu: #messageListMenu:shifted:.
	messageListView window: (0 @ 0 extent: 200 @ 12).
	topView addSubView: messageListView.

	browserCodeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@(200-12)).
	topView addSubView: browserCodeView below: messageListView.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView
