outputPortNumFromUser
	"Prompt the user for a MIDI output port. Answer a port number, or nil if the user does not select a port or if MIDI is not supported on this platform."
	"SimpleMIDIPort outputPortNumFromUser"

	| portCount aMenu dir |
	portCount _ self primPortCount.
	portCount = 0 ifTrue: [^ nil].
	aMenu _ CustomMenu new title: 'MIDI port for output:'.
	0 to: portCount - 1 do:[:i |
		dir _ self primPortDirectionalityOf: i.
		(dir = 2) | (dir = 3) ifTrue:[
			aMenu add: (self portDescription: i) action: i]].
	 ^ aMenu startUp
