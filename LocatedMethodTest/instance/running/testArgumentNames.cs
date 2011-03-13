testArgumentNames

	self assert: (LocatedMethod location: self t1 selector: #+) argumentNames = #(aNumber).
	self assert: (LocatedMethod location: self t1 selector: #!) argumentNames = #(aNumber).
	self assert: (LocatedMethod location: self t1 selector: #&&) argumentNames = #(anObject).
	self assert: (LocatedMethod location: self t1 selector: #@%+) argumentNames = #(anObject).
	
	self assert: (LocatedMethod location: self t1 selector: #mySelector) argumentNames = #().
	self assert: (LocatedMethod location: self t1 selector: #mySelector:) argumentNames = #(something).
	self assert: (LocatedMethod location: self t1 selector: #mySelector:and:) argumentNames = #(something somethingElse).
	
