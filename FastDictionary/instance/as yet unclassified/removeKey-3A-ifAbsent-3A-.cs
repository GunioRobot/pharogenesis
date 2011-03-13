removeKey: key ifAbsent: aBlock 
	"Remove key (and its associated value) from the receiver. If key is not in 
	the receiver, answer the result of evaluating aBlock. Otherwise, answer 
	the value externally named by key.
	If the key is cached, clear it's entry.  7/10/96 tk"

	key == key1 ifTrue: [key1 _ Array new: 1].	"Unique"
	key == key2 ifTrue: [key2 _ Array new: 1].	"Unique"
	key == key3 ifTrue: [key3 _ Array new: 1].	"Unique"
	key == key4 ifTrue: [key4 _ Array new: 1].	"Unique"
	^ super removeKey: key ifAbsent: aBlock