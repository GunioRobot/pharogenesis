subclasses
	"Return all the subclasses of nil"
	| classList |
	classList _ WriteStream on: Array new.
	self subclassesDo:[:class| classList nextPut: class].
	^classList contents