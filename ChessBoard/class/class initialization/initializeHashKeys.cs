initializeHashKeys
	"ChessGame initialize"
	| random |
	HashKeys _ Array new: 12.
	1 to: HashKeys size do:[:i| HashKeys at: i put: (WordArray new: 64)].
	HashLocks _ Array new: 12.
	1 to: HashLocks size do:[:i| HashLocks at: i put: (WordArray new: 64)].
	random _ Random seed: 23648646.
	1 to: 12 do:[:i|
		1 to: 64 do:[:j|
			(HashKeys at: i) at: j put: (random nextInt: SmallInteger maxVal) - 1.
			(HashLocks at: i) at: j put: (random nextInt: SmallInteger maxVal) - 1.
		].
	].

