testMethodsWithCallAndMethodsWithDisabledCall
	| methodRefs disabledMethodRefs enabledMethodRefs failedMethodRefs |
	self avoidSlowTest
		ifTrue: [^ self].
	disabledMethodRefs := pcc methodsWithDisabledCall.
	self assert: disabledMethodRefs size > 0.
	enabledMethodRefs := pcc methodsWithEnabledCall.
	self assert: enabledMethodRefs size > 0.
	failedMethodRefs := pcc methodsWithFailedCall.
	self assert: failedMethodRefs size > 0.
	methodRefs := pcc methodsWithCall.
	self assert: methodRefs size = (disabledMethodRefs size + enabledMethodRefs size + failedMethodRefs size)