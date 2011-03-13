classSendersOf: selector
	^ classSenders at: selector ifAbsent: [#()].