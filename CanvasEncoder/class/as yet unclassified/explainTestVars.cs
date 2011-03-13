explainTestVars
"
CanvasEncoder explainTestVars
"
	| answer total oneBillion data putter nReps |

	SimpleCounters ifNil: [^1 beep].
	total _ 0.
	oneBillion _ 1000 * 1000 * 1000.
	answer _ String streamContents: [ :strm |
		data _ SimpleCounters copy.
		putter _ [ :msg :index :nSec |
			nReps _ data at: index.
			total _ total + (nSec * nReps).
			strm nextPutAll: nReps asStringWithCommas,' * ',nSec printString,' ',
					(nSec * nReps / oneBillion roundTo: 0.01) printString,' secs for ',msg; cr
		].
		putter value: 'string socket' value: 1 value: 8000.
		putter value: 'rectangles' value: 2 value: 40000.
		putter value: 'points' value: 3 value: 18000.
		putter value: 'colors' value: 4 value: 8000.
	].
	StringHolder new
		contents: answer;
		openLabel: 'put integer times'.

