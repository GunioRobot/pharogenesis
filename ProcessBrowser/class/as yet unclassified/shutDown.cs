shutDown
	Browsers do: [ :ea | ea isAutoUpdating ifTrue: [ ea pauseAutoUpdate ]]