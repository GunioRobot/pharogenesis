readTrackEvents
	"Read the events of the current track."

	| cmd chan key vel ticks byte length |
	cmd _ #unknown.
	chan _ key _ vel _ 0.
	ticks _ 0.
	[trackStream atEnd] whileFalse: [
		ticks _ ticks + (self readVarLengthIntFrom: trackStream).
		byte _ trackStream next.
		byte >= 16rF0
			ifTrue: [  "meta or system exclusive event"
				byte = 16rFF ifTrue: [self metaEventAt: ticks].
				((byte = 16rF0) or: [byte = 16rF7]) ifTrue: [  "system exclusive data"
					length _ self readVarLengthIntFrom: trackStream.
					trackStream skip: length].
				cmd _ #unknown]
			ifFalse: [  "channel message event"
				byte >= 16r80
					ifTrue: [  "new command"
						cmd _ byte bitAnd: 16rF0.
						chan _ byte bitAnd: 16r0F.
						key _ trackStream next]
					ifFalse: [  "use running status"
						cmd == #unknown
							ifTrue: [self error: 'undefined running status; bad MIDI file?'].
						key _ byte].

				((cmd = 16rC0) or: [cmd = 16rD0]) ifFalse: [
					"all but program change and channel pressure have two data bytes"
					vel _ trackStream next].

				cmd = 16r90 ifTrue: [  "note on"
					vel = 0
						ifTrue: [self endNote: key chan: chan at: ticks]
						ifFalse: [self startNote: key vel: vel chan: chan at: ticks]].

				cmd = 16r80 ifTrue: [  "note off"
					self endNote: key chan: chan at: ticks]]].
