initialize: anIRCConnection
	connection _ anIRCConnection.
	channelList _ #().
	channelIndex _ 0.
	sortCriterion _ #name.
	anIRCConnection addDependent: self.
	self refreshChannelList.