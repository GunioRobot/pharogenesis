newFrom: aCollection
	"Compress aCollection into a ShortRunArray"
	| lastValue lastRun runs values |
	aCollection isEmpty ifTrue:[^self runs:#() values: #()].
	runs _ WriteStream on: (WordArray new: 100).
	values _ WriteStream on: (ShortIntegerArray new: 100).
	lastValue _ aCollection first.
	lastRun _ 0.
	aCollection do:[:item|
		(item = lastValue and:[lastRun < 16r8000]) ifTrue:[
			lastRun _ lastRun + 1.
		] ifFalse:[
			runs nextPut: lastRun.
			values nextPut: lastValue.
			lastRun _ 1.
			lastValue _ item.
		].
	].
	runs nextPut: lastRun.
	values nextPut: lastValue.
	^self runs: runs contents values: values contents