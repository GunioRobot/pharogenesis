save
	anyRemovalsSinceLastSave ifFalse: [
		"no removals have been made; thus, a true save isn't necessary"
		^self ].
	^super save