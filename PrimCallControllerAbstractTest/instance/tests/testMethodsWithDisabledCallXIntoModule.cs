testMethodsWithDisabledCallXIntoModule
	"precondition: all enabled"
	| methodRefs |
	self avoidSlowTest
		ifTrue: [^ self].
	"precondition: all enabled"
	pcc disableCallIn: self singularCallRef.
	methodRefs := pcc methodsWithDisabledCall: self singularCallName intoModule: self moduleNameWithSingularCallName.
	self assert: methodRefs size = 1.
	methodRefs := pcc methodsWithDisabledCall: self singularCallName intoModule: self moduleNameNotWithSingularCallName.
	self assert: methodRefs isEmpty.
	"postcondition"
	pcc enableCallIn: self singularCallRef