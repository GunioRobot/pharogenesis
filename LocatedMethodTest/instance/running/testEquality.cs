testEquality
	| locatedMethod1 locatedMethod2 |
	locatedMethod1 _ LocatedMethod location: self class selector: #testEquality.
	locatedMethod2 _ LocatedMethod location: self class selector: #testEquality.
	self assert: locatedMethod1 = locatedMethod2.
	self assert: locatedMethod1 hash = locatedMethod2 hash