testMirrorEqEq
	| stackpBefore stackpAfter |
	stackpBefore := thisContext stackPtr.
	self assert: (thisContext object: Array new eqeq: Array new) == false.
	self assert: (thisContext object: Array eqeq: Array) == true.
	stackpAfter := thisContext stackPtr.
	self assert: stackpBefore = stackpAfter "Make sure primitives pop all their arguments"