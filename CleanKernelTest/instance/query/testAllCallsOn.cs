testAllCallsOn
	"self run: #testAllCallsOn"
	self class forgetDoIts.
	self assert: (SystemNavigation new allCallsOn: #zoulouSymbol) size = 7.
	self assert: (SystemNavigation new allCallsOn: #callingAnotherMethod) size = 2