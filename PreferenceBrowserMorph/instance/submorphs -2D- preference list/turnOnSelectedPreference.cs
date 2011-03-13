turnOnSelectedPreference
	highlightedPreferenceButton 
		ifNotNilDo: [:m | m highlightOff].
	highlightedPreferenceButton := self selectedPreferenceButton
		highlightOn;
		yourself.
	self preferenceList scrollToShow: highlightedPreferenceButton bounds.