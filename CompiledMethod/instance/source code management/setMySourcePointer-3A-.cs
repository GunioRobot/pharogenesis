setMySourcePointer: srcPointer

	srcPointer = 0 ifTrue: [
		self at: self size put: 0.
		^self].
	(srcPointer between: 16r1000000 and: 16r4FFFFFF) ifFalse: [self error: 'Source pointer out of range'].
	self at: self size put: (srcPointer bitShift: -24) + 251.
	1 to: 3 do: [:i |
		self at: self size-i put: ((srcPointer bitShift: (i-3)*8) bitAnd: 16rFF)]