silentNightDuetExample4
	"
	DECTalkReader silentNightDuetExample4
	"

	| song1 song2 voice1 voice2 gestural1 gestural2 time |
	song1 := DECTalkReader silentNightVoice1 pitchBy: 0.5.
	song2 := DECTalkReader silentNightVoice2 pitchBy: 0.5.
	gestural1 := GesturalVoice new.
	gestural1 newHead position: 1 @ 50.
	voice1 := (KlattVoice new tract: 14.4) + gestural1.
	gestural2 := GesturalVoice new.
	gestural2 newHead position: 150 @ 50.
	voice2 := (KlattVoice new tract: 18.5; turbulence: 59) + gestural2.
	time := Time millisecondClockValue + 30000. "give it 30 secounds for precomputing"
	song1 playOn: voice1 at: time.
	song2 playOn: voice2 at: time