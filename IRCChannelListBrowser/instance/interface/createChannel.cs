createChannel
	|  channelName |
	channelName _ FillInTheBlank request: 'channel name'.
	channelName isEmpty ifTrue: [ ^self ].

	IRCChannelObserver openForChannelNamed: channelName  onConnection: connection