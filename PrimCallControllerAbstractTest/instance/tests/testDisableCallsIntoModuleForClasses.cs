testDisableCallsIntoModuleForClasses
	"wrong module"
	self
		should: [pcc disableCallsIntoModule: 'totallyRandom4711' forClasses: {self class}]
		raise: TestResult error.
	"precondition: all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"disabling"
	pcc disableCallsIntoModule: self exampleModuleName forClasses: {self class}.
	"now all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	"not enabled!"
	self
		should: [pcc disableCallsIntoModule: self exampleModuleName forClasses: {self class}]
		raise: TestResult error.
	"enabling"
	self methodRefsToExampleModule
		do: [:ref | pcc enableCallIn: ref].
	"all enabled now"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not enabled!"
	self
		should: [pcc disableCallsIntoModule: self failModuleName forClasses: {self class}]
		raise: TestResult error.
	pcc changeStatusOfFailedCalls.
	pcc disableCallsIntoModule: self failModuleName forClasses: {self class}.
	self assert: (pcc existsDisabledCallIn: self failedCallRef).
	"postcondition"
	pcc enableCallIn: self failedCallRef
