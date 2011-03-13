prepareState
	| nrsArray |
	self newEmptyStack.
	savedStacks := QuickIntegerDictionary new: (sender endPC).
	isStartOfBlock := false.
	nrsArray := self class neverRequiredSelectors.
	self assert:[nrsArray size = 5] because: 'Size of neverRequiredSelectors has been changed; re-optimize (by hand) #tallySelfSendsFor:'.
	nr1 := nrsArray at: 1.
	nr2 := nrsArray at: 2.
	nr3 := nrsArray at: 3.
	nr4 := nrsArray at: 4.
	nr5 := nrsArray at: 5.