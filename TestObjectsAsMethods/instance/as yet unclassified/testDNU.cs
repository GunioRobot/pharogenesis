testDNU 
	self class addSelector: #answer42 withMethod: AbstractObjectsAsMethod new.
	self should: [self answer42] raise: MessageNotUnderstood.
	self class basicRemoveSelector: #answer42.