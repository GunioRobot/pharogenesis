random: range
	"Answer a random integer between 0 and range."

	| r val |
	<primitive: 'randomRange' module: 'KedamaPlugin'>
	r _ range < 0 ifTrue: [range negated] ifFalse: [range].
	RandomSeed _ ((RandomSeed * 1309) + 13849) bitAnd: 65535.
	val _ (RandomSeed * (r + 1)) >> 16.
	^ range < 0 ifTrue: [val negated] ifFalse: [^ val].

