testExistsFailedCallIn
	self
		deny: (pcc existsFailedCallIn: self noExternalCallRef).
	self enabledCallRefs , self disabledCallRefs
		do: [:callRef | self
				deny: (pcc existsFailedCallIn: callRef)].
	self
		assert: (pcc existsFailedCallIn: self failedCallRef)