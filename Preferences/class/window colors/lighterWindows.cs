lighterWindows
	"Preferences lighterWindows"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	windowColorDict associationsDo:
		[:assoc | windowColorDict at: assoc key put: assoc value lighter]
