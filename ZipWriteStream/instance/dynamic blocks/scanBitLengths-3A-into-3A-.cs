scanBitLengths: bits into: anArray
	"Scan the trees and determine the frequency of the bit lengths.
	For repeating codes, emit a repeat count."
	| lastValue lastCount value |
	bits size = 0 ifTrue:[^self].
	lastValue _ bits at: 1.
	lastCount _ 1.
	2 to: bits size do:[:i|
		value _ bits at: i.
		value = lastValue 
			ifTrue:[lastCount _ lastCount + 1]
			ifFalse:[self scanBitLength: lastValue repeatCount: lastCount into: anArray.
					lastValue _ value.
					lastCount _ 1]].
	self scanBitLength: lastValue repeatCount: lastCount into: anArray.