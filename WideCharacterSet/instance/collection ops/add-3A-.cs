add: aCharacter 
	| val high low lowmap |
	val := aCharacter asciiValue.
	high := val bitShift: -16.
	low := val bitAnd: 16rFFFF.
	lowmap := map at: high ifAbsentPut: [WordArray new: 2048].
	self setBitmap: lowmap at: low.
	^ aCharacter