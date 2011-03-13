selfSendersOf: selector
	^ selfSenders at: selector ifAbsent: [#()].