testMethodsWithCallXIntoModule
	| methodRefs |
	self avoidSlowTest
		ifTrue: [^ self].
	methodRefs := pcc methodsWithCall: self singularCallName intoModule: self moduleNameWithSingularCallName.
	self assert: methodRefs size = 1.
	methodRefs := pcc methodsWithCall: self singularCallName intoModule: self moduleNameNotWithSingularCallName.
	self assert: methodRefs isEmpty