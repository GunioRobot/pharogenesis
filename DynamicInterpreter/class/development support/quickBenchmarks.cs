quickBenchmarks

	| iterations time times factor mark average result |
	iterations _ 5.
	factor _ 10.
	times _ SortedCollection new.
	Transcript cr.
	iterations timesRepeat: [
		Smalltalk garbageCollectMost.
		time _ Time millisecondsToRun: [(10 * factor) benchmark].
		mark _ 5000000 * 1000 * factor // time.
		Transcript show: mark printString; space; space.
		times add: mark].
	average _ (times removeFirst; removeLast; inject: 0 into: [:sum :next | sum + next]) // (iterations - 2).
	Transcript tab; tab; show: 'average = ' , average printString.
	times _ SortedCollection new.
	Transcript cr.
	iterations timesRepeat: [
		Smalltalk garbageCollectMost.
		time _ Time millisecondsToRun: [result _ 31 benchFib].
		mark _ result * 1000 // time.
		Transcript show: mark printString; space; space.
		times add: mark].
	average _ (times removeFirst; removeLast; inject: 0 into: [:sum :next | sum + next]) // (iterations - 2).
	Transcript tab; tab; show: 'average = ' , average printString.