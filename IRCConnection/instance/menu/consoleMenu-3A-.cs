consoleMenu: menu
	^menu
		labels: 'connect\disconnect\message of the day\channel list\talk to individual\inspect me' withCRs
		lines: #(2 4 5)
		selections: #(openConnectionDialogue disconnect openMotd openChannelList talkTo inspect)