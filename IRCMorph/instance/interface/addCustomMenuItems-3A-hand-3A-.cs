addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu  hand: aHandMorph.

	aCustomMenu addLine.
	aCustomMenu add: 'connect to server' action: #makeConnection.

	aCustomMenu addLine.
	aCustomMenu add: 'view MOTD' action: #openMotd.
	aCustomMenu add: 'view channel list' action: #openChannelList.