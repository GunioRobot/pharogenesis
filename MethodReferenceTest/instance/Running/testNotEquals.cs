testNotEquals
	| aMethodReference anotherMethodReference |
	aMethodReference _ MethodReference new.
	anotherMethodReference _ MethodReference new.
	""
	aMethodReference setStandardClass: String methodSymbol: #foo.
	anotherMethodReference setStandardClass: String class methodSymbol: #foo.
	" 
	differente classes, same selector -> no more equals"
	self
		shouldnt: [aMethodReference = anotherMethodReference].
	" 
	same classes, diferente selector -> no more equals"
	anotherMethodReference setStandardClass: String methodSymbol: #bar.
	self
		shouldnt: [aMethodReference = anotherMethodReference] 