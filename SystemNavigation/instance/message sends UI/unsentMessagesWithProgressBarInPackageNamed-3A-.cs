unsentMessagesWithProgressBarInPackageNamed: packageName
	| unsentMessages |
	unsentMessages := Set new.
	self
		doWithProgressBar: [:class :selector| 
			unsentMessages add: (MethodReference class: class selector: selector)] 
		forUnsentMessagesInPackageNamed: packageName.
	^unsentMessages