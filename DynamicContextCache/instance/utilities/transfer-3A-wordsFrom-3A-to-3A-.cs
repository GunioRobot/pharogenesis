transfer: num wordsFrom: src to: dst

	| in out ctr |
	self inline: false.
	in	_ src - 4.		"pre-increment is our friend on many architectures."
	out	_ dst - 4.
	ctr	_ num.
	[(ctr _ ctr - 1) >= 0] whileTrue: [
		self longAt: (out _ out + 4) put: (self longAt: (in _ in + 4)).
	].