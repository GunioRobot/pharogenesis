testChangeFailedCallSucceedingDisable
	pcc changeStatusOfFailedCalls.
	pcc disableCallIn: self failedCallRef.
	self
		assert: (pcc existsDisabledCallIn: self failedCallRef).
	"necessary for PCCByCompilation (to make it visible for initialization again)"
	pcc enableCallIn: self failedCallRef