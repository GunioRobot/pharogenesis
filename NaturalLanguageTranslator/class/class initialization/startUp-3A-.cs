startUp: resuming 
	| defaultID |
	resuming
		ifFalse: [^ self].
	""
	defaultID := LocaleID default.
	self cachedTranslations
		at: defaultID
		ifAbsent: [self localeID: defaultID].
	""
	self loadAvailableExternalLocales