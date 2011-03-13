filterTranslations: aString 
| filter |
filter := aString ifNil:[''].
""
	translationsFilter _ filter.
self update: #translations.
