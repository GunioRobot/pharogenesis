primitiveGetAttribute
	"Fetch the system attribute with the given integer ID. The result is a string, which will be empty if the attribute is not defined."

	| attr sz s |
	attr _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		sz _ self attributeSize: attr.
		s _ self instantiateClass: (self splObj: ClassString) indexableSize: sz.
		self getAttribute: attr Into: (s + BaseHeaderSize) Length: sz.
		self pop: 2.  "rcvr, attr"
		self push: s].
