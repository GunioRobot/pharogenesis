filterTranslations
	| filter |
	filter := UIManager default request: 'filter with
(empty string means no-filtering)' translated initialAnswer: self translationsFilter.
	""
	self filterTranslations: filter