reset
	"prepare for a new connection"
	recieveBuffer _ String new.
	protocolMessagesToSend _ OrderedCollection new.
	sendBuffer _ nil.
	socket _ nil.
	channelList _ nil.
	channelListBeingBuilt _ nil.
	motd _ nil.
	motdBeingBuilt _ nil.
	messagesProcessed _ 0.
	subscribedChannels _ Dictionary new.
