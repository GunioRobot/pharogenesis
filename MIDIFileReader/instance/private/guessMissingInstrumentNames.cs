guessMissingInstrumentNames
	"Attempt to guess missing instrument names from the first program change in that track."

	| progChange instrIndex instrName |
	1 to: tracks size do: [:i |
		(trackInfo at: i) isEmpty ifTrue: [
			progChange _ (tracks at: i) detect: [:e | e isProgramChange] ifNone: [nil].
			progChange ifNotNil: [
				instrIndex _ progChange program + 1.
				instrName _ self class standardMIDIInstrumentNames at: instrIndex.
				trackInfo at: i put: instrName]]].
