chooseFrom: labelList values: valueList lines: linesArray title: aString
	"Choose an item from the given list. Answer the selected item."
	
	^UITheme current
		chooseIn: self modalMorph
		title: aString
		labels: labelList
		values: valueList
		lines: linesArray