ircMessageRecieved: aMessage
	| sender newLine |

	sender _ aMessage sender ifNil: [ 'me' ].
	(sender includes: $!) ifTrue: [ sender _ sender copyFrom: 1 to: (sender indexOf: $!)-1 ].

	newLine _ 
		(Text string: sender emphasis: (Array with: TextEmphasis bold)), 
		': ', aMessage text, String cr.

	chatText _ chatText, newLine.
	chatText size > 2000 ifTrue: [
		chatText _ chatText copyFrom: (chatText size - 1000) to: chatText size ].

	self changed: #chatText.