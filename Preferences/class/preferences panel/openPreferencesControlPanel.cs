openPreferencesControlPanel
	"Open a preferences panel"

	"Preferences openPreferencesControlPanel"
	Smalltalk verifyMorphicAvailability ifFalse: [^ Beeper beep].
	^ self openFactoredPanel