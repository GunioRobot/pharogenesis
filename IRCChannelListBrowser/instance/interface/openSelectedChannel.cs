openSelectedChannel
	| channelInfo channelName |
	channelInfo _ channelList at: channelIndex ifAbsent: [ ^self ].
	channelName _ channelInfo name.

	IRCChannelObserver openForChannelNamed: channelName  onConnection: connection