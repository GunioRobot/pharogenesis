installTTF: ttfFileName asTextStyle: textStyleName sizes: sizeArray
	"TTFontReader
		installTTF: 'F:\fonts\amazon__.TTF' 
		asTextStyle: #Amazon
		sizes: #(24 60)"

	| ttf fontArray |
	ttf _ self parseFileNamed: ttfFileName.
	fontArray _ sizeArray collect:
		[:each |
		(ttf asStrikeFontScale: each / ttf unitsPerEm)
			name: textStyleName;
			pointSize: each].
	TextConstants at: textStyleName asSymbol put: (TextStyle fontArray: fontArray)