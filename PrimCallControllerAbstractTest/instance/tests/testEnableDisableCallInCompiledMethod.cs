testEnableDisableCallInCompiledMethod
	"Note: >>compiledMethodsToExampleModule has to be called frequently,  
	since the CMs are changing with a successful compile!"
	"precondition: all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"not disabled!"
	self
		should: [self compiledMethodsToExampleModule
				do: [:cm1 | pcc enableCallInCompiledMethod: cm1]]
		raise: TestResult error.
	"disabling"
	self compiledMethodsToExampleModule
		do: [:cm2 | pcc disableCallInCompiledMethod: cm2].
	"now all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	"not enabled!"
	self
		should: [self compiledMethodsToExampleModule
				do: [:cm3 | pcc disableCallInCompiledMethod: cm3]]
		raise: TestResult error.
	"enabling"
	"now this should work"
	self compiledMethodsToExampleModule
		do: [:cm4 | pcc enableCallInCompiledMethod: cm4].
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	"try caches"
	pcc disableEnabled.
	"all disabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	pcc enableDisabled.
	"all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule