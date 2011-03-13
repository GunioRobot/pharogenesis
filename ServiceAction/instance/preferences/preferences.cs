preferences
	^ {ServicePreferences preferenceAt: self shortcutPreference} select: [:e | e notNil]