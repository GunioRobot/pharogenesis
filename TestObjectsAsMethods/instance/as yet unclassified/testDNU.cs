testDNU
	self class addSelector: #answer42 withMethod: Object.
	self should: [self answer42] raise: MessageNotUnderstood.
	self class basicRemoveSelector: #answer42.