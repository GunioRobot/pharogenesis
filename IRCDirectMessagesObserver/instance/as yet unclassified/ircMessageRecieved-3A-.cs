ircMessageRecieved: aMessage
	| sender newLine |
	sender _ aMessage sender ifNil: [ 'me' ].
	(sender includes: $!) ifTrue: [ sender _ sender copyFrom: 1 to: (sender indexOf: $!)-1 ].

	talkingTo ifNotNil: [
		"only display messages to or from talkingTo"
		sender asIRCLowercase = talkingTo asIRCLowercase ifFalse: [^self ] ].

	newLine _ 
		(Text string: sender emphasis: (Array with: TextEmphasis bold)), 
		': ', aMessage text, String cr.

	self addToChatText: newLine.
