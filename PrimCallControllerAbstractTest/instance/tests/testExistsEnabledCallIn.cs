testExistsEnabledCallIn
	self
		deny: (pcc existsEnabledCallIn: self noExternalCallRef).
	self
		deny: (pcc existsEnabledCallIn: self failedCallRef).
	self enabledCallRefs
		do: [:callRef | self
				assert: (pcc existsEnabledCallIn: callRef)].
	self disabledCallRefs
		do: [:disabledRef | self
				deny: (pcc existsEnabledCallIn: disabledRef)]