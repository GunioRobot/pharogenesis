applyRuleTo: daysNamedInMonthList 
	"Private - Answer the day of the month selected from dayOfMonth list 
	by applying the receiver's rule."
	^ daysNamedInMonthList perform: selectionRule