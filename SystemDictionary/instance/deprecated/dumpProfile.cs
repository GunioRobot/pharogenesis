dumpProfile
	"Dump the profile database to a file."

	^self
		deprecated: 'Use SmalltalkImage current dumpProfile'
		block: [SmalltalkImage current dumpProfile]

