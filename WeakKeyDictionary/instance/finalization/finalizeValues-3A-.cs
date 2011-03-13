finalizeValues: finiObjects
	"Remove all associations with key == nil and value is in finiObjects.
	This method is folded with #rehash for efficiency."
	| oldArray assoc newIndex |
	oldArray _ array.
	array _ Array new: oldArray size.
	tally _ 0.
	1 to: array size do:[:i|
		assoc _ oldArray at: i.
		assoc ifNotNil:[
			(assoc key == nil and:[finiObjects includes: assoc value]) ifFalse:[
				newIndex _ self scanForNil: assoc key.
				self atNewIndex: newIndex put: assoc].
		].
	].