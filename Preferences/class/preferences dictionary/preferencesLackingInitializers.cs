preferencesLackingInitializers
	^ self allPreferenceFlagKeys copyWithoutAll: (self allPreferenceInitializationSpecs collect: [:info | info first])

"Preferences preferencesLackingInitializers"