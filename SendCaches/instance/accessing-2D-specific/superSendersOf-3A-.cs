superSendersOf: selector
	^ superSenders at: selector ifAbsent: [#()].