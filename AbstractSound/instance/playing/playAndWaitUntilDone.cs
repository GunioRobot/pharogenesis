playAndWaitUntilDone
	"Play this sound to the sound ouput port in real time."

	SoundPlayer playSound: self.
	[self samplesRemaining > 0] whileTrue.
