oopHasOkayClass: signedOop
	"Attempt to verify that the given oop has a reasonable behavior. The class must be a valid, non-integer oop and must not be nilObj. It must be a pointers object with three or more fields. Finally, the instance specification field of the behavior must match that of the instance."

	| oop oopClass formatMask behaviorFormatBits oopFormatBits |
	self var: #oop type: 'unsigned'.
	self var: #oopClass type: 'unsigned'.

	oop := self cCoerce: signedOop to: 'unsigned'.
	self okayOop: oop.
	oopClass := self cCoerce: (self fetchClassOf: oop) to: 'unsigned'.

	(self isIntegerObject: oopClass)
		ifTrue: [ self error: 'a SmallInteger is not a valid class or behavior' ].
	self okayOop: oopClass.
	((self isPointers: oopClass) and: [(self lengthOf: oopClass) >= 3])
		ifFalse: [ self error: 'a class (behavior) must be a pointers object of size >= 3' ].
	(self isBytes: oop)
		ifTrue: [ formatMask _ 16rC00 ]  "ignore extra bytes size bits"
		ifFalse: [ formatMask _ 16rF00 ].

	behaviorFormatBits _ (self formatOfClass: oopClass) bitAnd: formatMask.
	oopFormatBits _ (self baseHeader: oop) bitAnd: formatMask.
	behaviorFormatBits = oopFormatBits
		ifFalse: [ self error: 'object and its class (behavior) formats differ' ].
	^true