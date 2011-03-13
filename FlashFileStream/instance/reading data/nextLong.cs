nextLong
	| ulong |
	ulong := self nextULong.
	^ulong > 16r80000000
		ifTrue:[ulong - 16r100000000]
		ifFalse:[ulong]