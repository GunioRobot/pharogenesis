filterTranslations
	| filter |
	filter := FillInTheBlank request: 'filter with
(empty string means no-filtering)' translated initialAnswer: self translationsFilter.
	""
	self filterTranslations: filter