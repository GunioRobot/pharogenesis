test0FixturePutTest
	self shouldnt: self aValue raise: Error.
	self shouldnt: self anotherValue raise: Error.
	
	self shouldnt: self anIndex   raise: Error.
	self nonEmpty isDictionary 
		ifFalse:[self assert: (self anIndex >=1 & self anIndex <= self nonEmpty size).].
	
	self shouldnt: self empty raise: Error.
	self assert: self empty isEmpty .
	
	self shouldnt: self nonEmpty  raise: Error.
	self deny: self nonEmpty  isEmpty.