parseShiftSeqFromStream: aStream

	| c set target id |
	c _ aStream basicNext.
	c = $$ ifTrue: [
		set _ #multibyte.
		c _ aStream basicNext.
		c = $( ifTrue: [target _ 1].
		c = $) ifTrue: [target _ 2].
		target ifNil: [target _ 1. id _ c]
			ifNotNil: [id _ aStream basicNext].
	] ifFalse: [
		c = $( ifTrue: [target _ 1. set _ #nintyfour].
		c = $) ifTrue: [target _ 2. set _ #nintyfour].
		c = $- ifTrue: [target _ 2. set _ #nintysix].
		"target = nil ifTrue: [self errorMalformedInput]."
		id _ aStream basicNext.
	].
	(set = #multibyte and: [id = $B]) ifTrue: [
		state charSize: 2.
		target = 1 ifTrue: [
			state g0Size: 2.
			state g0Leading: 1.
		] ifFalse: [
			state g1Size: 2.
			state g1Leading: 1.
		].
		^ self
	].
	(set = #multibyte and: [id = $A]) ifTrue: [
		state charSize: 2.
		target = 1 ifTrue: [
			state g0Size: 2.
			state g0Leading: 2.
		] ifFalse: [
			state g1Size: 2.
			state g1Leading: 2.
		].
		^ self
	].

	(set = #nintyfour and: [id = $B or: [id = $J]]) ifTrue: [
		state charSize: 1.
		state g0Size: 1.
		state g0Leading: 0.
		^ self
	].
	(set = #nintysix and: [id = $A]) ifTrue: [
		state charSize: 1.
		state g1Size: 1.
		state g1Leading: 0.
		^ self
	].

	"self errorUnsupported."
