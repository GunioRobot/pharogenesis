compilerBenchmarks
	"InterpreterSupportCode compilerBenchmarks"

	| r t f b |
	f _ SortedCollection new.
	5 timesRepeat:
		[t _ Time millisecondsToRun: [r _ 30 benchFib].
		 f add: r*1000//t].
	b _ SortedCollection new.
	5 timesRepeat:
		[b add: (20000000 * 1000 // (Time millisecondsToRun: [40 benchmark]))].
	Transcript cr; print: f; cr; print: b.
	f _ (f removeFirst; removeLast; inject: 0 into: [:sum :elt | sum + elt]) // f size.
	b _ (b removeFirst; removeLast; inject: 0 into: [:sum :elt | sum + elt]) // b size.
	Transcript cr;
		show: f printString; tab;
		show: b printString