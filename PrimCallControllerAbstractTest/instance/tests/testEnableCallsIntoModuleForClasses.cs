testEnableCallsIntoModuleForClasses
	"wrong module"
	self
		should: [pcc enableCallsIntoModule: 'totallyRandom4711' forClasses: {self class}]
		raise: TestResult error.
	"precondition: all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not disabled!"
	self
		should: [pcc enableCallsIntoModule: self exampleModuleName forClasses: {self class}]
		raise: TestResult error.
	"disabling"
	self methodRefsToExampleModule
		do: [:ref | pcc disableCallIn: ref].
	"now all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	"enabling"
	"now this should work"
	pcc enableCallsIntoModule: self exampleModuleName forClasses: {self class}.
	"all enabled now"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not disabled!"
	self
		should: [pcc enableCallsIntoModule: self failModuleName forClasses: {self class}]
		raise: TestResult error.
	pcc changeStatusOfFailedCalls.
	pcc enableCallsIntoModule: self failModuleName forClasses: {self class}.
	self assert: (pcc existsEnabledCallIn: self failedCallRef)
