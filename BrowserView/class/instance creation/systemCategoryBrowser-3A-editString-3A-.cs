systemCategoryBrowser: aBrowser editString: aString 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of five subviews, starting with the list view of the currently selected 
	system class category--a single item list. The initial text view part is a 
	view of the characters in aString."

	| browserView systemCategoryListView classListView switchView
		messageCategoryListView messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	systemCategoryListView _ self buildSystemCategoryListView: aBrowser.
	classListView _ self buildClassListView: aBrowser.
	switchView _ self buildInstanceClassSwitchView: aBrowser.
	messageCategoryListView _ self buildMessageCategoryListView: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: aString.

	systemCategoryListView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	systemCategoryListView singleItemMode: true.
	systemCategoryListView noTopDelimiter.
	systemCategoryListView noBottomDelimiter.
	systemCategoryListView list: systemCategoryListView getList.

	browserView addSubView: systemCategoryListView.
	browserView addSubView: classListView.
	browserView addSubView: switchView.
	browserView addSubView: messageCategoryListView.
	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	switchView 
		align: switchView viewport topLeft 
		with: classListView viewport bottomLeft.
	messageCategoryListView 
		align: messageCategoryListView viewport topLeft 
		with: classListView viewport topRight.
	messageListView 
		align: messageListView viewport topLeft 
		with: messageCategoryListView viewport topRight.
	browserCodeView 
		window: browserCodeView window 
		viewport: (switchView viewport bottomLeft 
						corner: messageListView viewport bottomRight + (0 @ 110)).
	systemCategoryListView 
		window: systemCategoryListView window 
		viewport: (classListView viewport topLeft - (0 @ 12) 
						corner: messageListView viewport topRight).
    
	aString notNil ifTrue: [aBrowser lock].

	^browserView