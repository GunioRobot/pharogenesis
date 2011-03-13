collectPointersTo: anObject 
	"Find all occurrences in the system of pointers to the argument anObject."
	| some |
	Smalltalk garbageCollect.
	"Big collection shouldn't grow, so collector is always same"
	some _ OrderedCollection new: 100.
	self pointersTo: anObject do:
		[:obj | obj ~~ some collector ifTrue: [some add: obj]].
	^ some asArray

	"(Smalltalk collectPointersTo: Browser) inspect."
