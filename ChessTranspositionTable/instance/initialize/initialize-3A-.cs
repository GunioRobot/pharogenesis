initialize: nBits
	"Initialize the receiver using 1<<nBits entries. See also ChessPlayerAI>>initializeTranspositionTable."
	| entry |
	array _ Array new: 1 << nBits.
	used _ ReadWriteStream on: (Array new: 50000). "<- will grow if not sufficient!"
	entry _ ChessTTEntry new clear.
	1 to: array size do:[:i| array at: i put: entry clone].
	collisions _ 0.
	Smalltalk garbageCollect. "We *really* want them old here"