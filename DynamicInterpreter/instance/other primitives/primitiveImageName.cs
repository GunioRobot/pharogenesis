primitiveImageName
	"When called with a single string argument, record the string as the current image file name. When called with zero arguments, return a string containing the current image file name."

	| s sz |
	argumentCount = 1 ifTrue: [
		s _ self stackTop.
		self successIfClassOf: s is: (self splObj: ClassString).
		successFlag ifTrue: [
			sz _ self stSizeOf: s.
			self imageNamePut: (s + BaseHeaderSize) Length: sz.
			self pop: 1.  "pop s, leave rcvr on stack"
		].
	] ifFalse: [
		sz _ self imageNameSize.
		s _ self instantiateClass: (self splObj: ClassString) indexableSize: sz.
		self imageNameGet: (s + BaseHeaderSize) Length: sz.
		self pop: 1.  "rcvr"
		self push: s.
	].
