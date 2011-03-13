startUp: resuming
	| newID |
	resuming ifFalse: [^self].
	(Preferences valueOfFlag: #useLocale)
		ifTrue: [
			newID := self current determineLocaleID.
			newID ~= LocaleID current
				ifTrue: [self switchToID: newID]]