uniqueDateStringBetween: aStart and: anEnd
	"Return a String, with just enough information to distinguish it from other dates in the range."

	"later, be more sophisticated"
	self deprecated: 'Deprecated'.

	aStart year + 1 >= anEnd year ifFalse: [^ self printFormat: #(1 2 3 $  3 1)].	"full"
	aStart week next >= anEnd week ifFalse: [^ self printFormat: #(2 1 9 $  3 1)]. "May 6"
	^ self weekday
