openMessageEditString: aString
	"Create a pluggable version of the views for a Browser that just shows one message."
	| messageListView browserCodeView topView annotationPane underPane y |

	Smalltalk isMorphic ifTrue: [^ self openAsMorphMessageEditing: aString].

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

	 self wantsAnnotationPane
		ifTrue:
			[annotationPane _ PluggableTextView on: self
				text: #annotation accept: nil
				readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 200@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: messageListView.
			underPane _ annotationPane.
			y _ (200 - 12) - self optionalAnnotationHeight]
		ifFalse:
			[underPane _ messageListView.
			y _ 200 - 12].

	browserCodeView _ MvcTextEditor default on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	browserCodeView window: (0@0 extent: 200@y).
	topView addSubView: browserCodeView below: underPane.
	aString ifNotNil: [browserCodeView editString: aString.
			browserCodeView hasUnacceptedEdits: true].
	^ topView