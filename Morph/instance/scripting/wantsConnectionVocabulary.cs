wantsConnectionVocabulary
	submorphs ifNil: [ ^true ].	"called from EToyVocabulary>>initialize after basicNew"

	^ (Preferences valueOfFlag: #alwaysShowConnectionVocabulary)
		or: [ self connections isEmpty not ]