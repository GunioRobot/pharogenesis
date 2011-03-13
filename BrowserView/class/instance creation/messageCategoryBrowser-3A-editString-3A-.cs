messageCategoryBrowser: aBrowser editString: aString 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of three subviews, starting with the list view of message categories in 
	the model's currently selected class. The initial text view part is a view 
	of the characters in aString."

	| browserView messageCategoryListView messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	messageCategoryListView _ self buildMessageCategoryListView: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: aString.

	messageCategoryListView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	messageCategoryListView singleItemMode: true.
	messageCategoryListView noTopDelimiter.
	messageCategoryListView noBottomDelimiter.
	messageCategoryListView list: messageCategoryListView getList.

	browserView addSubView: messageCategoryListView.
	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	messageCategoryListView 
		window: messageCategoryListView window 
		viewport: (messageListView viewport topLeft - (0 @ 12) 
						corner: messageListView viewport topRight).
	browserCodeView 
		window: browserCodeView window 
		viewport: (messageListView viewport bottomLeft 
						corner: messageListView viewport bottomRight + (0 @ 110)).
    
	aString notNil ifTrue: [aBrowser lock].

	^browserView