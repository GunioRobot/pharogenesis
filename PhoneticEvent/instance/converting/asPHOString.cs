asPHOString
	| stream |
	stream := WriteStream on: String new.
	stream
		nextPutAll: (PhonemeSet arpabetToSampa at: self phoneme); space;
		print: (self duration * 1000) rounded.
	self pitchPoints do: [ :each | stream space; print: (each x * 1000) rounded; space; print: each y rounded].
	^ stream contents