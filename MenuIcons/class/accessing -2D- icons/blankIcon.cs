blankIcon
	^ Icons
		at: #blankIcon
		ifAbsentPut: [ Form
				extent: 16 @ 16
				depth: 8 ] 