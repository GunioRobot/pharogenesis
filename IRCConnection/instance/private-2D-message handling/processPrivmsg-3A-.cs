processPrivmsg: aMessage
	"handle a PRIVMSG or NOTICE message"
	| sender recipient text privMessage info |

	"put together the message"
	sender _ aMessage prefix.
	recipient _ aMessage arguments at: 1.
	text _ aMessage arguments at: 2.
	privMessage _ IRCMessage sender: sender  recipient: recipient  text: text.

	"broadcast the message to all subscribers"
	info _ subscribedChannels at: recipient asIRCLowercase ifAbsent: [ nil ].
	info ifNotNil: [ info subscribers do: [ :sub |
		sub ircMessageRecieved: privMessage ] ].
	recipient asIRCLowercase = nick asIRCLowercase ifTrue: [
		directMessageSubscribers do: [ :sub |
			sub ircMessageRecieved: privMessage ] ].
