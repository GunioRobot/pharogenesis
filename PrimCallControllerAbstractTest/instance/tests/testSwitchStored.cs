testSwitchStored
	| refs |
	"all enabled, precondition"
	self assert: (pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class) size = self numOfCallsExampleModule.
	refs := self methodRefsToExampleModule.
	"fill cache"
	refs
		do: [:ref | pcc disableCallIn: ref].
	"enable one"
	pcc enableCallIn: refs first.
	self
		assert: (pcc existsEnabledCallIn: refs first).
	self
		assert: (pcc existsDisabledCallIn: refs second).
	"switching"
	pcc switchStored.
	"now the checks go vice versa"
	self
		assert: (pcc existsDisabledCallIn: refs first).
	self
		assert: (pcc existsEnabledCallIn: refs second).
	pcc enableCallIn: refs first.
	self
		assert: (pcc existsEnabledCallIn: refs first)