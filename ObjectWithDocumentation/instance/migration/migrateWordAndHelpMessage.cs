migrateWordAndHelpMessage
	"Migrate the English wording and help message to the new structure"

	| englishElement |
	self initWordingAndDocumentation.
	(self properties includes: #wording)
		ifFalse: [
			englishElement := self naturalLanguageTranslations
				detect: [:each | each language == #English] ifNone: [^nil].
			self wording: englishElement wording.
			self helpMessage: englishElement helpMessage]