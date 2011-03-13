bachFugue
	"A fugue by J. S. Bach."
	"AbstractSound bachFugue play"

	"BoinkSound		bachFugueVoice1 play"
	"WaveTableSound	bachFugueVoice1 play"
	"PluckedSound		bachFugueVoice1 play"
	"FMSound			bachFugueVoice1 play"

	^ MixedSound new
		add: BoinkSound bachFugueVoice1 pan: 200;
		add: WaveTableSound bachFugueVoice2 pan: 800;
		add: FMSound bachFugueVoice3 pan: 400;
		add: FMSound bachFugueVoice4 pan: 600.
