testMethodsWithDisabledCallX
	| methodRefs |
	self avoidSlowTest
		ifTrue: [^ self].
	"precondition: all enabled"
	pcc disableCallIn: self singularCallRef.
	methodRefs := pcc methodsWithDisabledCall: self singularCallName.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol = self singularCallName).
	"postcondition"
	pcc enableCallIn: self singularCallRef