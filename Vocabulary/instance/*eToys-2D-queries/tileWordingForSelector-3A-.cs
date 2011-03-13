tileWordingForSelector: aSelector
	"Answer the wording to emblazon on tiles representing aSelector"

	| anInterface inherent |
	anInterface := self methodInterfaceAt: aSelector asSymbol ifAbsent:
		[inherent := Utilities inherentSelectorForGetter: aSelector.
		^ inherent
			ifNil:
				[self translatedWordingFor: aSelector]
			ifNotNil:
				[inherent translated]].
	^ anInterface wording