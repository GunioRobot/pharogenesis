methodDescriptionForSelector: aSymbol
	"Return a TraitMethodDescription for the selector aSymbol."

	| description |
	description _ TraitMethodDescription selector: aSymbol.
	self transformations do: [:each |
		each collectMethodsFor: aSymbol into: description].
	^description