testChangeFailedCallSucceedingEnable
	pcc changeStatusOfFailedCalls.
	pcc enableCallIn: self failedCallRef.
	self
		assert: (pcc existsEnabledCallIn: self failedCallRef)