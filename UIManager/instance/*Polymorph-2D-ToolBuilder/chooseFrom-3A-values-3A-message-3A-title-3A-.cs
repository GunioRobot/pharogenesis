chooseFrom: aList values: valueList message: messageString title: aString
	"Choose an item from the given list. Answer the index of the selected item."
	
	^self chooseFrom: aList values: valueList lines: #() message: messageString title: aString