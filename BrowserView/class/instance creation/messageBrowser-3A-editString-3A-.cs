messageBrowser: aBrowser editString: aString 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of two subviews, starting with the list view of message selectors in the 
	model's currently selected category. The initial text view part is a view 
	of the characters in aString."

	| browserView messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: aString.

	messageListView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	messageListView singleItemMode: true.
	messageListView noTopDelimiter.
	messageListView noBottomDelimiter.
	messageListView list: messageListView getList.

	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	messageListView 
		window: messageListView window 
		viewport: (browserCodeView viewport topLeft - (0 @ 12) 
						corner: browserCodeView viewport topRight).
    
	aString notNil ifTrue: [aBrowser lock].

	^browserView