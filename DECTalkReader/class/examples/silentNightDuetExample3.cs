silentNightDuetExample3
	"
	DECTalkReader silentNightDuetExample3
	"

	| song1 song2 voice1 voice2 time |
	song1 := DECTalkReader silentNightVoice1 pitchBy: 0.25.
	song2 := DECTalkReader silentNightVoice2 pitchBy: 0.25.
	voice1 := KlattVoice new tract: 18.5; turbulence: 59.
	voice2 := KlattVoice new tract: 20; flutter: 0.5.
	time := Time millisecondClockValue + 30000. "give it 30 secounds for precomputing"
	song1 playOn: voice1 at: time.
	song2 playOn: voice2 at: time