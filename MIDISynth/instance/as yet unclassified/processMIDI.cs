processMIDI
	"Process some MIDI commands. Answer true if any commands were processed."

	| didSomething cmdByte byte1 byte2 cmd chan |
	didSomething _ false.
	midiParser midiDo: [:item |
		didSomething _ true.
		cmdByte _ item at: 2.
		byte1 _ byte2 _ nil.
		item size > 2 ifTrue: [
			byte1 _ item at: 3.
			item size > 3 ifTrue: [byte2 _ item at: 4]].
		cmdByte < 240
			ifTrue: [  "channel message" 
				cmd _ cmdByte bitAnd: 2r11110000.
				chan _ (cmdByte bitAnd: 2r00001111) + 1.
				(channels at: chan) doChannelCmd: cmd byte1: byte1 byte2: byte2]
			ifFalse: [  "system message"
				"process system messages here"
			]].
	^ didSomething
