testIsSelfEvaluating
	self assert: (a isSelfEvaluating).
	
	self assert: (a printString = '1->''one''')
