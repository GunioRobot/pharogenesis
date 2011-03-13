test: n  "Time millisecondsToRun: [LargePositiveInteger test: 100] 1916"
	| f f1 |
	"Test and time mult, div, add, subtract"
	f _ n factorial.
	f1 _ f*(n+1).
	n timesRepeat: [f1 _ f1 - f].
	f1 = f ifFalse: [self halt].
	n timesRepeat: [f1 _ f1 + f].
	f1 // f = (n+1) ifFalse: [self halt].
	f1 negated = (Number readFrom: '-' , f1 printString) ifFalse: [self halt].

	"Check normalization and conversion to/from SmallInts"
	(SmallInteger maxVal + 1 - 1) == SmallInteger maxVal ifFalse: [self halt].
	(SmallInteger maxVal + 3 - 6) == (SmallInteger maxVal-3) ifFalse: [self halt].
	(SmallInteger minVal - 1 + 1) == SmallInteger minVal ifFalse: [self halt].
	(SmallInteger minVal - 3 + 6) == (SmallInteger minVal+3) ifFalse: [self halt].

	"Check bitShift from and back to SmallInts"
	1 to: 257 do: [:i | ((i bitShift: i) bitShift: 0-i) == i ifFalse: [self halt]].
