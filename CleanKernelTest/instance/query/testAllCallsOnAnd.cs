testAllCallsOnAnd
	"self run: #testAllCallsOnAnd"
	self class forgetDoIts.
	self assert: (SystemNavigation new allCallsOn: #zoulouSymbol and: #callingAThirdMethod) size = 2.
	self assert: (SystemNavigation new allCallsOn: #callingAThirdMethod and: #inform:) size = 1