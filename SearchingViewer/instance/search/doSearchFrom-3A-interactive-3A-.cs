doSearchFrom:  aSource interactive: isInteractive
	"Perform the search operation.  If interactive is true, this actually happened because a search button was pressed; if false, it was triggered some other way for which an informer would be inappropriate."

	| searchFor aVocab aList all anInterface useTranslations scriptNames addedMorphs |
	searchString _ (aSource isKindOf: PluggableTextMorph)
		ifFalse:
			[aSource]
		ifTrue:
			[aSource text string].
	searchFor _ searchString asString asLowercase withBlanksTrimmed.

	aVocab _ self outerViewer currentVocabulary.
	(useTranslations _ (scriptedPlayer isPlayerLike) and: [aVocab isEToyVocabulary])
		ifTrue:
			[all _ scriptedPlayer costume selectorsForViewer.
			all addAll: (scriptNames _ scriptedPlayer class namedTileScriptSelectors)]
		ifFalse:
			[all _ scriptNames _ scriptedPlayer class allSelectors].
	aList _ all select:
		[:aSelector | (aVocab includesSelector: aSelector forInstance: scriptedPlayer ofClass: scriptedPlayer class limitClass: ProtoObject) and:
			[(useTranslations and: [(anInterface _ aVocab methodInterfaceAt: aSelector ifAbsent: [nil]) notNil and: [anInterface wording includesSubstring: searchFor caseSensitive: false]])
				or:
					[((scriptNames includes: aSelector) or: [useTranslations not]) and:
						[aSelector includesSubstring: searchFor caseSensitive: false]]]].
	aList _ aList asSortedArray.

	self removeAllButFirstSubmorph. "that being the header"
	self addAllMorphs:
		((addedMorphs _ scriptedPlayer tilePhrasesForSelectorList: aList inViewer: self)).
	self enforceTileColorPolicy.
	self secreteCategorySymbol.
	self world ifNotNil: [self world startSteppingSubmorphsOf: self].
	self adjustColorsAndBordersWithin.

	owner ifNotNil: [owner isStandardViewer ifTrue: [owner fitFlap].

	(isInteractive and: [addedMorphs isEmpty]) ifTrue:
		[self inform: ('No matches found for "' translated), searchFor, '"']]