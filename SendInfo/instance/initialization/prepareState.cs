prepareState
	| nrsArray |
	self newEmptyStack.
	savedStacks _ QuickIntegerDictionary new: (sender endPC).
	isStartOfBlock _ false.
	nrsArray _ self class neverRequiredSelectors.
	self assert:[nrsArray size = 5] because: 'Size of neverRequiredSelectors has been changed; re-optimize (by hand) #tallySelfSendsFor:'.
	nr1 _ nrsArray at: 1.
	nr2 _ nrsArray at: 2.
	nr3 _ nrsArray at: 3.
	nr4 _ nrsArray at: 4.
	nr5 _ nrsArray at: 5.