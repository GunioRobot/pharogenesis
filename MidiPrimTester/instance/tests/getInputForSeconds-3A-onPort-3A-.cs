getInputForSeconds: seconds onPort: portNum
	"Collect MIDI input from the given port for the given number of seconds, and answer a string describing the data read."
	"MidiPrimTester new getInputForSeconds: 5 onPort: 0"

	| buf bufList endTime n midiStartTime s t |
	"collect the data"
	self openPort: portNum andDo: [
		buf _ ByteArray new: 1000.
		bufList _ OrderedCollection new.
		midiStartTime _ self primMIDIGetClock.
		endTime _ Time millisecondClockValue + (seconds * 1000).
		[Time millisecondClockValue < endTime] whileTrue: [
			n _ self primMIDIReadPort: portNum into: buf.
			n > 0 ifTrue: [bufList add: (buf copyFrom: 1 to: n)].
			(Delay forMilliseconds: 5) wait]].

	"format the data into a string"
	s _ WriteStream on: String new.
	s cr.
	bufList do: [:b |
		t _ (self bufferTimeStampFrom: b) - midiStartTime.
		s print: t.
		s nextPutAll: ': '.
		5 to: b size do: [:i | s print: (b at: i); space].
		s cr].
	^ s contents
