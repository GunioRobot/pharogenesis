testEnableDisableCallInMethodClass
	| sels |
	sels := self methodSelectorsToExampleModule.
	"wrong call"
	self
		should: [pcc disableCallInMethod: #nonExistingCall class: self class]
		raise: TestResult error.
	"wrong class"
	self
		should: [pcc disableCallInMethod: sels first class: Integer]
		raise: TestResult error.
	"wrong call"
	self
		should: [pcc enableCallInMethod: #nonExistingCall class: self class]
		raise: TestResult error.
	"wrong class"
	self
		should: [pcc enableCallInMethod: sels first class: Integer]
		raise: TestResult error.
	self
		should: [pcc enableCallInMethod: self noExternalCallSelector class: self class]
		raise: TestResult error.
	"precondition: all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not disabled!"
	self
		should: [sels
				do: [:sel1 | pcc enableCallInMethod: sel1 class: self class]]
		raise: TestResult error.
	"disabling"
	sels
		do: [:sel2 | pcc disableCallInMethod: sel2 class: self class].
	"now all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	"not enabled!"
	self
		should: [sels
				do: [:sel3 | pcc disableCallInMethod: sel3 class: self class]]
		raise: TestResult error.
	"enabling"
	"now this should work"
	sels
		do: [:sel4 | pcc enableCallInMethod: sel4 class: self class].
	"all enabled now"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"try caches"
	pcc disableEnabled.
	"all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	pcc enableDisabled.
	"all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule