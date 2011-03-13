classBrowser: aBrowser editString: aString 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of four subviews, starting with the list view of classes in the model's 
	currently selected system category. The initial text view part is a view 
	of the characters in aString."

	| browserView classListView messageCategoryListView switchView
	messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	classListView _ self buildClassListView: aBrowser.
	switchView _ self buildInstanceClassSwitchView: aBrowser.
	messageCategoryListView _ self buildMessageCategoryListView: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: aString.

	classListView borderWidthLeft: 2 right: 0 top: 2 bottom: 0.
	classListView singleItemMode: true.
	classListView noTopDelimiter.
	classListView noBottomDelimiter.
	classListView list: classListView getList.
	switchView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.

	browserView addSubView: classListView.
	browserView addSubView: switchView.
	browserView addSubView: messageCategoryListView.
	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	messageListView 
		align: messageListView viewport topLeft 
		with: messageCategoryListView viewport topRight.
	classListView 
		window: classListView window 
		viewport: (messageCategoryListView viewport topLeft - (0 @ 12) 
					corner: messageCategoryListView viewport topRight).
	switchView 
		window: switchView window 
		viewport: (messageListView viewport topLeft - (0 @ 12) 
					corner: messageListView viewport topRight).
	browserCodeView 
		window: browserCodeView window 
		viewport: (messageCategoryListView viewport bottomLeft 
					corner: messageListView viewport bottomRight + (0 @ 110)).
    
	aString notNil ifTrue: [aBrowser lock].

	^browserView