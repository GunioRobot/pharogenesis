removeEnvelope
	(PopUpMenu confirm: 'Really remove ' , envelope name , '?')
		ifFalse: [^ self].
	sound removeEnvelope: envelope.
	self editEnvelope: sound envelopes first.