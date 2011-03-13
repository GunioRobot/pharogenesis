setBitmap: aMap at: shortInteger
	"set a single bit in aMap.
	shortInteger should be between: 0 and: 16rFFFF"
	
	| collecIndex bitIndex |
	collecIndex := shortInteger bitShift: -5.
	bitIndex := shortInteger bitAnd: 16r1F.
	^aMap at: collecIndex + 1 put: ((aMap at: collecIndex + 1) bitOr: (1 bitShift: bitIndex))