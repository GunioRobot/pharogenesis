fetchIntegerOrTruncFloat: fieldIndex ofObject: objectPointer
	"Return the integer value of the given field of the given object. If the field contains a Float, truncate it and return its integral part. Fail if the given field does not contain a small integer or Float, or if the truncated Float is out of the range of small integers."
	"Note: May be called by translated primitive code."

	| intOrFloat floatVal frac trunc |
	self inline: false.
	self var: #floatVal declareC: 'double floatVal'.
	self var: #frac declareC: 'double frac'.
	self var: #trunc declareC: 'double trunc'.

	intOrFloat _ self fetchPointer: fieldIndex ofObject: objectPointer.
	(self isIntegerObject: intOrFloat) ifTrue: [^ self integerValueOf: intOrFloat].
	self assertClassOf: intOrFloat is: (self splObj: ClassFloat).
	successFlag ifTrue: [
		self fetchFloatAt: intOrFloat + BaseHeaderSize into: floatVal.
		self cCode: 'frac = modf(floatVal, &trunc)'.
		"the following range check is for C ints, with range -2^31..2^31-1"
		self cCode: 'success((-2147483648.0 <= trunc) && (trunc <= 2147483647.0))'].
	successFlag
		ifTrue: [^ self cCode: '((int) trunc)']
		ifFalse: [^ 0].
