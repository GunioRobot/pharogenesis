testExistsDisabledCallIn
	self
		deny: (pcc existsDisabledCallIn: self noExternalCallRef).
	self
		deny: (pcc existsDisabledCallIn: self failedCallRef).
	self enabledCallRefs
		do: [:callRef | self
				deny: (pcc existsDisabledCallIn: callRef)].
	self disabledCallRefs
		do: [:disabledRef | self
				assert: (pcc existsDisabledCallIn: disabledRef)]