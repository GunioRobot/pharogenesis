initializeAddedPreferences
	"Initialize any preference not yet known to the prefs dictionary as per descriptions in the 'initial values' category, but don't change the setting of any existing preference.
	Also, compile accessor methods for retrieving any preference that lacks one"

	"Preferences initializeAddedPreferences"

	| sym |
	self allPreferenceInitializationSpecs do:
		[:triplet |
			(self class selectors includes: (sym _ triplet first))
				ifFalse:
					[self compileAccessMethodFor: sym].
			(FlagDictionary includesKey: sym) ifFalse:
				[triplet second == #true
					ifTrue:
						[self enable: sym]
					ifFalse:
						[self disable: sym]]].
	self resetCategoryInfo

