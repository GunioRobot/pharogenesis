privmsgFrom: from  to: to  text: text
	"send a private message.  'to' can be a channel name...."
	| msg |
	msg _ (IRCProtocolMessage
		prefix: from
		command: 'privmsg'
		arguments: (Array with: to  with: text)).

	self processMessage: msg.	"because these aren't sent back by default"
	self sendMessage: msg.