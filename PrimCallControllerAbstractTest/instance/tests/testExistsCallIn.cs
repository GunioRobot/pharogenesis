testExistsCallIn
	self
		deny: (pcc existsCallIn: self noExternalCallRef).
	self enabledCallRefs , self disabledCallRefs , {self failedCallRef}
		do: [:callRef | self
				assert: (pcc existsCallIn: callRef)]