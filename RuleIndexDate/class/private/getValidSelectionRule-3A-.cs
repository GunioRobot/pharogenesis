getValidSelectionRule: dayListIndex 
	"Private - Answer the dayListIndex position in the list of all days named 
	(Sunday, etc) in a month,  Report an error if dayListIndex does not 
	represent an <Integer>."
	dayListIndex isInteger ifFalse: [^ self error: 'Not an Integer.'].
	^ dayListIndex