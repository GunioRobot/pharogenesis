chooseInitialSettings
	"Restore the default choices for Preferences."
	"Preferences chooseInitialSettings"

	self allPreferenceInitializationSpecs do:
		[:aSpec |
			aSpec second == #true
				ifTrue:
					[self enable: aSpec first]
				ifFalse:
					[self disable: aSpec first]].
	self resetCategoryInfo

