channelDescriptions
	^channelList collect: [ :channel |
		channel name, '(', channel numUsers printString, ')    ', channel topic].