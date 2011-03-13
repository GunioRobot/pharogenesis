testBinarySelectors
	self assert: (LocatedMethod location: self t1 selector: #+) isBinarySelector.
	self assert: (LocatedMethod location: self t1 selector: #!) isBinarySelector.
	self assert: (LocatedMethod location: self t1 selector: #&&) isBinarySelector.
	self assert: (LocatedMethod location: self t1 selector: #@%+) isBinarySelector.
	
	self deny: (LocatedMethod location: self t1 selector: #mySelector) isBinarySelector.
	self deny: (LocatedMethod location: self t1 selector: #mySelector:) isBinarySelector.
	self deny: (LocatedMethod location: self t1 selector: #mySelector:and:) isBinarySelector.
	
	