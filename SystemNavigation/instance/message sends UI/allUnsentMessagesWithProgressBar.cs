allUnsentMessagesWithProgressBar
	| unsentMessages |
	unsentMessages := Set new.
	self
		doWithProgressBarForAllUnsentMessages: [:class :selector| 
			unsentMessages add: (MethodReference class: class selector: selector)].
	^unsentMessages