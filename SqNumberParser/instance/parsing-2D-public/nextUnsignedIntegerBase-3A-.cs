nextUnsignedIntegerBase: aRadix 
	"Form an unsigned integer with incoming digits from sourceStream.
	Count the number of digits and the lastNonZero digit and store int in
	instVar "
	
	^ self
		nextUnsignedIntegerBase: aRadix
		ifFail: [self expected: 'a digit between 0 and 9']