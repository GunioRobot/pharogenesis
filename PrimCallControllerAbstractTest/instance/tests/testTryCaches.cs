testTryCaches
	| refs |
	"all enabled, precondition"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	refs := self methodRefsToExampleModule.
	"fill cache"
	refs
		do: [:ref | pcc disableCallIn: ref].
	"try caches"
	pcc enableDisabled.
	"all enabled"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	pcc disableEnabled.
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = 0.
	pcc enableDisabled.
	"all enabled, postcondition"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule