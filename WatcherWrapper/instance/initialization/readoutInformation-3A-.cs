readoutInformation: aGetter 
	"Answer a triplet of {type. wording. setter}"
	| info anInterface |
	info := player slotInfoForGetter: aGetter.
	"In case of a variable"
	info
		ifNotNil: [^ {info type. Utilities inherentSelectorForGetter: aGetter. Utilities setterSelectorFor: variableName}].
	"In case of a slot"
	anInterface := Vocabulary eToyVocabulary
				methodInterfaceAt: aGetter
				ifAbsent: [^ {#Unknown. '*'. nil}].
	^ {anInterface resultType. anInterface wording. anInterface companionSetterSelector}