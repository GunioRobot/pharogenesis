testChangeFailedCallFailing
	pcc preserveStatusOfFailedCalls.
	self
		should: [pcc enableCallIn: self failedCallRef]
		raise: TestResult error.
	self
		should: [pcc disableCallIn: self failedCallRef]
		raise: TestResult error