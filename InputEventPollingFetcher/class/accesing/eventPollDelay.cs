eventPollDelay
	^ EventPollDelay ifNil: [ EventPollDelay := Delay forMilliseconds: 10 ].