fill: num wordsFrom: dst with: val
	"Note: this could be rewritten to use memset() in the C translation."

	| out ctr |
	self inline: true.
	out	_ dst - 4.		"pre-increment is our friend on many architectures."
	ctr	_ num.
	[(ctr _ ctr - 1) >= 0] whileTrue: [
		self longAt: (out _ out + 4) put: val.
	].