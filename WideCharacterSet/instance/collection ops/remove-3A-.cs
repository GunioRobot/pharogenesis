remove: aCharacter 
	| val high low lowmap |
	val := aCharacter asciiValue.
	high := val bitShift: -16.
	low := val bitAnd: 16rFFFF.
	lowmap := (map
				at: high
				ifAbsent: [^ aCharacter]) self clearBitmap: lowmap at: low.
	lowmap max = 0
		ifTrue: [map removeKey: high].
	^ aCharacter