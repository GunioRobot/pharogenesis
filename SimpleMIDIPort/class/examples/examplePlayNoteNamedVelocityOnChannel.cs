examplePlayNoteNamedVelocityOnChannel
	"self examplePlayNoteNamedVelocityOnChannel"
	
	|aPort|
	aPort:= self openOnPortNumber: 0.
	#('Bottle Blow' 'Shakuhachi' 'Whistle' 'Ocarina' 'Lead 1 (square)' 'Lead 2 (sawtooth)' 'Lead 3 (caliope lead)' 'Lead 4 (chiff lead)' 'Lead 5 (charang)' 'Lead 6 (voice)' 'Lead 7 (fifths)' 'Lead 8 (brass + lead)' 'Pad 1 (new age)' 'Pad 2 (warm)' 'Pad 3 (polysynth)' 'Pad 4 (choir)' 'Pad 5 (bowed)' 'Pad 6 (metallic)' 'Pad 7 (halo)' 'Pad 8 (sweep)' 'FX 1 (rain)' 'FX 2 (soundtrack)' 'FX 3 (crystal)' 'FX 4 (atmosphere)' 'FX 5 (brightness)' 'FX 6 (goblins)' 'FX 7 (echoes)' 'FX 8 (sci-fi)' 'Sitar' 'Banjo' 'Shamisen' 'Koto' 'Kalimba' 'Bagpipe' 'Fiddle' 'Shanai' 'Tinkle Bell' 'Agogo' 'Steel Drums' 'Woodblock' 'Taiko Drum' 'Melodic Tom' 'Synth Drum' 'Reverse Cymbal' 'Guitar Fret Noise' 'Breath Noise' 'Seashore' 'Bird Tweet' 'Telephone Ring' 'Helicopter' 'Applause' 'Gunshot' ) do: [:anInstrumentName | 
	[aPort useInstrument: anInstrumentName onChannel: 0.
	aPort playNoteNamed: 'c4' onChannel: 0.
	(Delay forMilliseconds: 250) wait.
	aPort stopNoteNamed: 'c4' onChannel: 0] ensure: [aPort close]]