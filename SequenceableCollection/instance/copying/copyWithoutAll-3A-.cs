copyWithoutAll: aList
	"Answer a copy of the receiver in which all occurrences of all elements in aList have been removed.  6/17/96 sw"

	| aStream |
	aStream _ WriteStream on: (self species new: self size).
	self do: [:each | (aList includes: each) ifFalse: [aStream nextPut: each]].
	^ aStream contents