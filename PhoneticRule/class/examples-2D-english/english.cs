english
	"Answer the english phonetic rules."
	| answer |
	answer := OrderedCollection new.
	#(englishPunctuationRules
		englishARules englishBRules englishCRules englishDRules englishERules
		englishFRules englishGRules englishHRules englishIRules englishJRules
		englishKRules englishLRules englishMRules englishNRules englishORules
		englishPRules englishQRules englishRRules englishSRules englishTRules
		englishURules englishVRules englishWRules englishXRules englishYRules
		englishZRules) do: [ :each | answer addAll: (self perform: each)].
	^ answer asArray