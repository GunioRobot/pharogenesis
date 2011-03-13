testAnswer42 
	self class addSelector: #answer42 withMethod: ObjectsAsMethodsExample new.
	self assert: self answer42 = 42.
	self class basicRemoveSelector: #answer42.