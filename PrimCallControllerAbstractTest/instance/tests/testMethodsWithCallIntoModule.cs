testMethodsWithCallIntoModule
	| methodRefs |
	self avoidSlowTest ifTrue: [^ self].
	"precondition: all enabled"
	pcc disableCallIn: self methodRefsToExampleModule first.
	methodRefs := pcc methodsWithCallIntoModule: self exampleModuleName.
	self assert: methodRefs size = self numOfCallsExampleModule.
	"postcondition"
	pcc enableCallIn: self methodRefsToExampleModule first