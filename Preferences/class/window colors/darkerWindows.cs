darkerWindows
	"Preferences darkerWindows"
	| windowColorDict |
	windowColorDict _ self parameterAt: #windowColors default: [IdentityDictionary new].

	windowColorDict associationsDo:
		[:assoc | windowColorDict at: assoc key put: assoc value darker]
