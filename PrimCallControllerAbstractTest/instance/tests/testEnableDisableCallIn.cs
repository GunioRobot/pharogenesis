testEnableDisableCallIn
	| refs |
	refs := self methodRefsToExampleModule.
	"wrong call"
	self
		should: [pcc disableCallIn: self wrongCallRef]
		raise: TestResult error.
	"wrong class"
	self
		should: [pcc disableCallIn: self wrongClassRef]
		raise: TestResult error.
	"wrong call"
	self
		should: [pcc enableCallIn: self wrongCallRef]
		raise: TestResult error.
	"wrong class"
	self
		should: [pcc enableCallIn: self wrongClassRef]
		raise: TestResult error.
	"no external call"
	self
		should: [pcc enableCallIn: self noExternalCallRef]
		raise: TestResult error.
	"precondition: all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not disabled!"
	self
		should: [refs
				do: [:ref1 | pcc enableCallIn: ref1]]
		raise: TestResult error.
	"disabling"
	refs
		do: [:ref2 | pcc disableCallIn: ref2].
	"now all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	"not enabled!"
	self
		should: [refs
				do: [:ref3 | pcc disableCallIn: ref3]]
		raise: TestResult error.
	"enabling"
	"now this should work"
	refs
		do: [:ref4 | pcc enableCallIn: ref4].
	"all enabled now"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"try caches"
	pcc disableEnabled.
	"all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	pcc enableDisabled.
	"all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule