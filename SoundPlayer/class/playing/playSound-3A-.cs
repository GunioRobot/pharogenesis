playSound: aSound
	"Reset and start playing the given sound from its beginning."

	aSound reset.
	self resumeSound: aSound.