testComparingEqual
	
	self assert: ((BlockClosureTest>>#exempleClosureEqual1) createBlock: self) 
		= ((BlockClosureTest>>#exempleClosureEqual2)  createBlock: self).