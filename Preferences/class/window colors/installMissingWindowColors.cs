installMissingWindowColors
	"Install the factory-provided bright window colors for tools not yet in the dictionary -- a one-time bootstrap"

	"Preferences installMissingWindowColors"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	self windowColorTable do:
		[:colorSpec |
			(windowColorDict includesKey: colorSpec classSymbol) ifFalse:
				[windowColorDict at: colorSpec classSymbol put: (Color colorFrom: colorSpec brightColor)]]