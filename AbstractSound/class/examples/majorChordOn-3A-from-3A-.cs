majorChordOn: aSound from: aPitch
	"FMSound majorChord play"
	| score majorScale leadingRest pan note |
	majorScale _ self majorPitchesFrom: aPitch.
	score _ MixedSound new.
	leadingRest _ pan _ 0.
	#(1 3 5 8) do: [:noteIndex |
		note _ aSound copy
			setPitch: (majorScale at: noteIndex)
			dur: 2.0 - leadingRest
			loudness: 0.3.
		score add: (RestSound dur: leadingRest), note pan: pan.
		leadingRest _ leadingRest + 0.2.
		pan _ pan + 0.3].
	^ score
