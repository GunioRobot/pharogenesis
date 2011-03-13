random: range
	"Answer a random integer between 0 and range."

	RandomSeed := ((RandomSeed * 1309) + 13849) bitAnd: 65535.
	^ (RandomSeed * (range + 1)) // 65536
