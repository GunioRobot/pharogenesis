colorForRow: 	row
	^(selectedRow notNil and: [ row = selectedRow])
		ifTrue: [ Color red ]
		ifFalse: [ self color ].