legacyHelpMessage
	"If I have a help message stashed in my legacy naturalTranslations slot, answer its translated rendition, else answer nil.  If I *do* come across a legacy help message, transfer it to my properties dictionary."

	| untranslated |
	naturalLanguageTranslations isEmptyOrNil  "only in legacy (pre-3.8) projects"
		ifTrue: [^ nil].
	untranslated _ naturalLanguageTranslations first helpMessage ifNil: [^ nil].
	self propertyAt: #helpMessage put: untranslated.
	naturalLanguageTranslations removeFirst.
	naturalLanguageTranslations isEmpty ifTrue: [naturalLanguageTranslations _ nil].
	^ untranslated translated