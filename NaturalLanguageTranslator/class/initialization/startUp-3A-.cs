startUp: resuming 
	| defaultID |
	resuming
		ifFalse: [^ self].
	""
	defaultID := LocaleID current.
	self cachedTranslations
		at: defaultID
		ifAbsent: [self localeID: defaultID].
	""
	self loadAvailableExternalLocales