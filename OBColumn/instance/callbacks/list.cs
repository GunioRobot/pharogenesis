list
	^ children 
		ifNil: [#()]
		ifNotNil: [children collect: [:ea | ea displayString]]