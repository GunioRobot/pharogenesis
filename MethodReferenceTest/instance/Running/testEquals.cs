testEquals
	| aMethodReference anotherMethodReference |
	aMethodReference _ MethodReference new.
	anotherMethodReference _ MethodReference new.
	" 
	two fresh instances should be equals between them"
	self
		should: [aMethodReference = anotherMethodReference].
	self
		should: [aMethodReference hash = anotherMethodReference hash].
	" 
	two instances representing the same method (same class and  
	same selector) should be equals"
	aMethodReference setStandardClass: String methodSymbol: #foo.
	anotherMethodReference setStandardClass: String methodSymbol: #foo.
	self
		should: [aMethodReference = anotherMethodReference].
	self
		should: [aMethodReference hash = anotherMethodReference hash] 