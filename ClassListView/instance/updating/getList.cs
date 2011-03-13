getList 
	"Refer to the comment in BrowserListView|getList."

	| selectedClassName |
	singleItemMode
		ifTrue: 
			[selectedClassName _ model selectedClassName.
			selectedClassName == nil ifTrue: [selectedClassName _ '    '].
			^Array with: selectedClassName asSymbol]
		ifFalse: [^model classList]