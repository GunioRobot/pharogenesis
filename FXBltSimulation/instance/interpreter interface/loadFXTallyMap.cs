loadFXTallyMap
	"Load the tally map"
	| map |
	self inline: true.
	map _ interpreterProxy fetchPointer: FXTallyMapIndex ofObject: bitBltOop.
	map = interpreterProxy nilObject ifTrue:[
		tallyMap _ nil.
		tallyMapSize _ 0.
		^true].
	(interpreterProxy isWords: map) ifFalse:[^false].
	tallyMapSize _ interpreterProxy slotSizeOf: map.
	tallyMap _ interpreterProxy firstIndexableField: map.
	^interpreterProxy failed not