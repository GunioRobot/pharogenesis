testMethodsWithCallX
	| methodRefs |
	self avoidSlowTest
		ifTrue: [^ self].
	methodRefs := pcc methodsWithCall: self singularCallName.
	self assert: methodRefs size = 1