getValidSelectionRule: selectionBlock 
	"Private - Answer the selectionBlock to select the date given the 
	dayName (Sunday, etc) dayOfMonth list,  Report an error if 
	selectionBlock does not represent a <monadicValuable> block."
	((selectionBlock isMemberOf: BlockContext)
		and: [selectionBlock argumentCount = 1])
		ifFalse: [^ self error: 'Not an <monadicValuable> block.'].
	^ selectionBlock