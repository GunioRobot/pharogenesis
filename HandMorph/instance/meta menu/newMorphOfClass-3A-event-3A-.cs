newMorphOfClass: morphClass event: evt
	"Attach a new morph of the given class to the invoking hand."

	| m |
	m _ morphClass new.
	m installModelIn: owner.  "a chance to install model pointers"
	evt hand attachMorph: m.
	owner startSteppingSubmorphsOf: m.
