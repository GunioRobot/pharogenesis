toggleFreqFilterState
	sortByFreq _ sortByFreq not.
	self changed: #freqFilterState.
	self changed: #contactList.