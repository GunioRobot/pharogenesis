initializeMessageHandlers
	"initilize the table mapping IRC commands to processing methods"
	"IRCConnection initializeMessageHandlers"

	MessageHandlers _ Dictionary new.
	#(
		372		processMotd:
		377		processMotd:
		375		processMotdStart:
		376		processMotdEnd:

		ping	processPing:

		join		processJoin:
		part	processPart:
		quit		processQuit:

		privmsg		processPrivmsg:
		notice		processPrivmsg:

		321		processChannelListStart:
		322		processChannelList:
		323		processChannelListEnd:

		331		processNoTopic:
		332		processTopic:
		topic	processTopic:

		353		processNamReply:
	) pairsDo: [ :command  :method |
		MessageHandlers at: command asString put: method ].
