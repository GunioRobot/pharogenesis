filterTranslations: aString 
| filter |
filter := aString ifNil:[''].
""
	translationsFilter := filter.
self update: #translations.
