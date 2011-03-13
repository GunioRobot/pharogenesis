discardSoundAndSpeech
	"NOTE: This leaves 26 references to obsolete classes, one in SystemDictionary
	class>>initialize, one in ImageSegment>>restoreEndianness, one in DataStream
	class>>initialize and 23 in Morphic and Flash classes."

	SystemOrganization removeCategoriesMatching: 'Sound-*'.
	SystemOrganization removeCategoriesMatching: 'Speech-*'.
	Smalltalk removeClassNamed: #KlattSynthesizerPlugin.
	Smalltalk removeSelector: #(DigitalSignatureAlgorithm randomBitsFromSoundInput:).
	Smalltalk removeSelector: #(Project beep).
	Preferences setPreference: #soundsEnabled toValue: false