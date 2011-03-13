getPortList
	"Return a string that describes this platform's MIDI ports."
	"MidiPrimTester new getPortList"

	| s portCount dir directionString |
	s _ WriteStream on: String new.
	s cr; nextPutAll: 'MIDI Ports:'; cr.
	portCount _ self primMIDIGetPortCount.
	0 to: portCount - 1 do: [:i |
		s tab.
		s print: i; nextPutAll: ': '. 
		s nextPutAll: (self primMIDIGetPortName: i).
		dir _ self primMIDIGetPortDirectionality: i.
		directionString _ dir printString.  "default"
		dir = 1 ifTrue: [directionString _ '(in)'].
		dir = 2 ifTrue: [directionString _ '(out)'].
		dir = 3 ifTrue: [directionString _ '(in/out)'].
		s space; nextPutAll: directionString; cr].
	^ s contents
