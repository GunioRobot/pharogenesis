unsentMessagesWithProgressBarInClass: aClass
	| unsentMessages |
	unsentMessages := Set new.
	self
		doWithProgressBar: [:class :selector| 
			unsentMessages add: (MethodReference class: class selector: selector)] 
		forUnsentMessagesInClass: aClass.
	^unsentMessages