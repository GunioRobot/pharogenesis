testFindMatchFor
	| soundBuffer bestMatch |
	soundBuffer := SoundBuffer fromArray: (Array new: 512 withAll: 0).
	bestMatch := recognizer findMatchFor: soundBuffer samplingRate: 22050.
	"Because the sound buffer is empty, the recognizer should find nothing but an empty  phoneme record."
	self assert: bestMatch name = '...'.
	 