toggleClassListIndex: anInteger 
	"If anInteger is the current class index, deselect it. Else make it the 
	current class selection."

	self classListIndex: 
		(classListIndex = anInteger
			ifTrue: [0]
			ifFalse: [anInteger])