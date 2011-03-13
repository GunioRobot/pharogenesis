primitiveSoundGetVolume
	"Set the sound input recording level."
	| left right results | 
	self primitive: 'primitiveSoundGetVolume'
		parameters: #( ).
	self var: #left declareC: 'double left'.
	self var: #right declareC: 'double right'.
	left _ 0.
	right _ 0.
	self cCode: 'snd_Volume((double *) &left,(double *) &right)'.
	interpreterProxy pushRemappableOop: (right asOop: Float).
	interpreterProxy pushRemappableOop: (left asOop: Float).
	interpreterProxy pushRemappableOop: (interpreterProxy instantiateClass: (interpreterProxy classArray) indexableSize: 2).
	results _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: results withValue: interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 1 ofObject: results withValue: interpreterProxy popRemappableOop.
	^ results