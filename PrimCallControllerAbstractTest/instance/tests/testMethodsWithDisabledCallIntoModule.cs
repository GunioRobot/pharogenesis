testMethodsWithDisabledCallIntoModule
	| methodRefs |
	self avoidSlowTest ifTrue: [^ self].
	"precondition: all enabled"
	pcc disableCallIn: self methodRefsToExampleModule first.
	methodRefs := pcc methodsWithDisabledCallIntoModule: self exampleModuleName.
	self assert: methodRefs size = 1.
	"postcondition"
	pcc enableCallIn: self methodRefsToExampleModule first