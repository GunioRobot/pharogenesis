channelInfo: channelName
	"return cached info on a channel"
	| lChannelName |
	lChannelName _ channelName asIRCLowercase.
	^subscribedChannels at: lChannelName ifAbsent: [ 
		"no info available--create and return a skeleton"
		subscribedChannels at: lChannelName put:
			(IRCChannelInfo forChannelNamed: channelName  onConnection: self) ]