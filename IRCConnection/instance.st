Model
	subclass: #IRCConnection
	instanceVariableNames:
		'socket protocolMessagesToSend sendBuffer recieveBuffer nick userName fullName server port channelList channelListBeingBuilt motd motdBeingBuilt subscribedChannels directMessageSubscribers protocolMessageSubscribers consoleText messagesProcessed '
	classVariableNames: 'DefaultFullName DefaultNick DefaultPort DefaultServer DefaultUserName MessageHandlers '
	poolDictionaries: ''
	category: 'Network-IRC Chat'