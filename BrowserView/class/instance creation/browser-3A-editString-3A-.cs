browser: aBrowser editString: aString 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of five subviews, starting with the list view of system categories. The 
	initial text view part is a view of the characters in aString."

	| browserView systemCategoryListView classListView messageCategoryListView
	switchView messageListView browserCodeView |

	browserView _ self new model: aBrowser.
	systemCategoryListView _ self buildSystemCategoryListView: aBrowser.
	classListView _ self buildClassListView: aBrowser.
	switchView _ self buildInstanceClassSwitchView: aBrowser.
	messageCategoryListView _ self buildMessageCategoryListView: aBrowser.
	messageListView _ self buildMessageListView: aBrowser.
	browserCodeView _ self buildBrowserCodeView: aBrowser editString: aString.

	browserView addSubView: systemCategoryListView.
	browserView addSubView: classListView.
	browserView addSubView: switchView.
	browserView addSubView: messageCategoryListView.
	browserView addSubView: messageListView.
	browserView addSubView: browserCodeView.

	classListView 
		align: classListView viewport topLeft 	
		with: systemCategoryListView viewport topRight.
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
		align: browserCodeView viewport topLeft 
		with: systemCategoryListView viewport bottomLeft.
    
	aString notNil ifTrue: [aBrowser lock].

	^browserView