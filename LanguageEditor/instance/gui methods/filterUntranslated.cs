filterUntranslated
	| filter |
	filter := FillInTheBlank request: 'filter with
(empty string means no-filtering)' translated initialAnswer: self untranslatedFilter.
	""
	self filterUntranslated: filter