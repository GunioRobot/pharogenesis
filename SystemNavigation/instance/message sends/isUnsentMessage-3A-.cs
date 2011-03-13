isUnsentMessage: selector
	^(self allSendersOf: selector) isEmpty 