getList 
	"Refer to the comment in BrowserListView|getList."

	| selectedMessageName |
	singleItemMode
		ifTrue: 
			[selectedMessageName _ model selectedMessageName.
			selectedMessageName == nil ifTrue: [selectedMessageName _ '    '].
			^Array with: selectedMessageName asSymbol]
		ifFalse: [^model messageList]