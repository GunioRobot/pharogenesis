clearProfile
	"Clear the profile database."

	^self deprecated: 'Use SmalltalkImage current clearProfile'
		block: [SmalltalkImage current  clearProfile].