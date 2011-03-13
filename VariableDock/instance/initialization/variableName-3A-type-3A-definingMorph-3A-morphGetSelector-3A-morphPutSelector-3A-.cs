variableName: aSymbol type: aType definingMorph: aMorph morphGetSelector: getterSymbol morphPutSelector: putterSymbol
	"Initialize the receiver as indicated"

	variableName _ aSymbol asSymbol.
	type _ aType.
	definingMorph _ aMorph.
	morphGetSelector _ getterSymbol.
	morphPutSelector _ putterSymbol.
	self computePlayerGetterAndSetterSelectors