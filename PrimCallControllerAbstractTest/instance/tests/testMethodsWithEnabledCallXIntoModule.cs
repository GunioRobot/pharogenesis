testMethodsWithEnabledCallXIntoModule
	"precondition: all enabled"
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCall: self singularCallName intoModule: self moduleNameWithSingularCallName.
	self assert: methodRefs size = 1.
	methodRefs := pcc methodsWithEnabledCall: self singularCallName intoModule: self moduleNameNotWithSingularCallName.
	self assert: methodRefs isEmpty