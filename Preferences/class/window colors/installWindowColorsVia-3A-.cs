installWindowColorsVia: colorSpecBlock
	"Install windows colors using colorSpecBlock to deliver the color source for each element; the block is handed a WindowColorSpec object"

	"Preferences installBrightWindowColors"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	self windowColorTable do:
		[:aColorSpec |
			windowColorDict at: aColorSpec classSymbol put: (Color colorFrom: (colorSpecBlock value: aColorSpec))]