ircMessageRecieved: aMessage
	| sender newLine |

	Smalltalk beep.

	sender _ aMessage sender ifNil: [ 'me' ].
	(sender includes: $!) ifTrue: [ sender _ sender copyFrom: 1 to: (sender indexOf: $!)-1 ].

	newLine _ 
		(Text string: sender emphasis: (Array with: TextEmphasis bold)), 
		': ', aMessage text, String cr.

	self addToConsole: newLine.