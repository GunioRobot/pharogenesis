setActualFont: aFont
	"Set the value of actualFont, from a TextFontReference"

	actualFont _ aFont.
	aFont textStyle ifNotNilDo: [ :ts | fontNumber _ ts fontIndexOf: aFont ]