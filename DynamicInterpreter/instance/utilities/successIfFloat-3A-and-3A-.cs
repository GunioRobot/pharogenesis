successIfFloat: oop1 and: oop2
	"Fail unless both arguments are floats."

	| floatClass |
	((oop1 bitOr: oop2) bitAnd: 1) ~= 0 ifTrue: [
		successFlag _ false.
	] ifFalse: [
		floatClass _ self splObj: ClassFloat.
		self successIfClassOf: oop1 is: floatClass.
		self successIfClassOf: oop2 is: floatClass.
	].