artists

	selection1 = 'reggae' ifTrue: [^ list2].
	selection1 = 'early' ifFalse: [^ #('ziggy' 'marley')].
	^ #()