testSwitchPrimCallOffOn
	| res |
	pcc disableCallInMethod: self realExternalCallOrPrimitiveFailedSelector class: self class.
	self
		should: [self perform: self realExternalCallOrPrimitiveFailedSelector]
		raise: TestResult error.
	pcc enableCallInMethod: self realExternalCallOrPrimitiveFailedSelector class: self class.
	self
		shouldnt: [res := self perform: self realExternalCallOrPrimitiveFailedSelector]
		raise: TestResult error.
	self assert: res isString