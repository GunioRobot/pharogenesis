storeSegment
	"Store my project out on the disk as an ImageSegment.  Keep the outPointers in memory.  Name it <my name>.seg."

	| is roots |
	is _ ImageSegment new.
	is segmentName: self name.
	roots _ OrderedCollection new: self size * 2.
	"roots addFirst: self."
	self valuesDo:
		[:value | value == self ifFalse: [roots addLast: value].
		value class class == Metaclass ifTrue: [roots addLast: value class]].
	is copyFromRootsLocalFileFor: roots sizeHint: 0.

	"NOTE: self is now an ISRootStub..."
	is state = #tooBig ifTrue: [^ false].
	is extract.
	is state = #active ifFalse: [^ false].
	is writeToFile: is segmentName.
	^ true
