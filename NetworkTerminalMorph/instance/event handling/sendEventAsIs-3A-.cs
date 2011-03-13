sendEventAsIs: evt

	eventEncoder ifNil: [ ^self ].
	eventEncoder sendEvent: evt.