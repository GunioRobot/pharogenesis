darkenStandardWindowPreferences
	"Make all window-color preferences one shade darker"

	| windowColorDict |
	windowColorDict _ self parameterAt: #windowColors ifAbsentPut: [IdentityDictionary new].

	windowColorDict associationsDo:
		[:assoc | windowColorDict at: assoc key put: assoc value darker]

"Preferences darkenStandardWindowPreferences"
