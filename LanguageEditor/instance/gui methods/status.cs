status
	"answer a status string"
	| translationsSize untranslatedSize |
	translationsSize := self translator translations size.
	untranslatedSize := self translator untranslated size.
	^ 'ÆÀ {1} phrases ÆÀ {2} translated ÆÀ {3} untranslated ÆÀ' translated format: {translationsSize + untranslatedSize. translationsSize. untranslatedSize}