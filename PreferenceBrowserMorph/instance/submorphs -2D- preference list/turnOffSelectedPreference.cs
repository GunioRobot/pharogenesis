turnOffSelectedPreference
	highlightedPreferenceButton 
		ifNil: [^self].
	highlightedPreferenceButton highlightOff.
	highlightedPreferenceButton := nil.