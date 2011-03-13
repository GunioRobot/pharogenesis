updateInstrumentsFromLibrary
	"The instrument library has been modified. Update my instruments with the new versions from the library. Use a single instrument prototype for all parts with the same name; this allows the envelope editor to edit all the parts by changing a single sound prototype."

	| myInstruments name |
	myInstruments _ Dictionary new.
	1 to: instrumentSelector size do: [:i |
		name _ (instrumentSelector at: i) contents.
		(myInstruments includesKey: name) ifFalse: [
			myInstruments at: name put:
				(name = 'clink'
					ifTrue: [
						(SampledSound
							samples: SampledSound coffeeCupClink
							samplingRate: 11025) copy]
					ifFalse: [
						(AbstractSound
							soundNamed: name
							ifAbsent: [
								(instrumentSelector at: i) contentsClipped: 'default'.
								FMSound default]) copy])].
		scorePlayer instrumentForTrack: i put: (myInstruments at: name)].
