capitalized
	"Return a copy with the first letter capitalized"
	| cap |
	cap _ self copy.
	cap at: 1 put: (cap at: 1) asUppercase.
	^ cap