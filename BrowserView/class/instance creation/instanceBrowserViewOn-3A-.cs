instanceBrowserViewOn: aBrowser
	"Answer an instance of me on the model, aBrowser, which looks at a user-defined instance-class. The view has three subviews.  "

	| browserView  messageCategoryListView messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	messageCategoryListView _ self buildMessageCategoryListView: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: nil.

	browserView addSubView: messageCategoryListView.
	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	messageListView 
		align: messageListView viewport topLeft 
		with: messageCategoryListView viewport topRight.

	browserCodeView 
		window: browserCodeView window 
		viewport: (messageCategoryListView viewport bottomLeft 
					corner: messageListView viewport bottomRight + (0 @ 110)).

	^ browserView