addPhoneme
	"Record and add a new phoneme example to my phoneme set. Prompt the user for its name and mouth position."

	| phoneme |
	self stopRecognizing.
	Utilities
		informUser: 'Press and hold the mouse button while speaking the phoneme.'
		during: [Sensor waitButton].
	soundInput isRecording ifTrue: [self stop].
	phoneme := PhonemeRecord new initialize.
	phoneme recordWithLevel: soundInput recordLevel.
	phoneme samples size < 10000 ifTrue: [
		^ self inform: 'Nothing recorded; check the record input source and adjust the level'].

	self promptForDetailsOfPhoneme: phoneme.
	recognizer phonemes add: phoneme.
