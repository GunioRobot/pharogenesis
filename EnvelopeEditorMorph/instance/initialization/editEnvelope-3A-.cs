editEnvelope: env
	envelope _ env.
	limits _ Array with: envelope loopStartIndex
				with: envelope loopEndIndex
				with: envelope points size.
	limitXs _ limits collect: [:i | (envelope points at: i) x].
	self buildView