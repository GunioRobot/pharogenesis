initialize 
	|  connectButton column channelListButton motdButton consoleView inputPane |
	super initialize.

	connection _ IRCConnection new.

	server _ DefaultServer.
	port _ DefaultPort.
	nick _ DefaultNick.
	userName _ DefaultUserName.
	fullName _ DefaultFullName.

	self setLabel: 'IRC'.
	self extent: 200@100.

	column _ AlignmentMorph newColumn.

	connectButton _ PluggableButtonMorph
		on: self
		getState: nil
		action: #openConnection.
	connectButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'connect to server'.
	column addMorphBack: connectButton.

	motdButton _ PluggableButtonMorph
		on: self
		getState: nil
		action: #openMotd.
	motdButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'view MOTD'.
	column addMorphBack: motdButton.

	channelListButton _ PluggableButtonMorph
		on: self
		getState: nil
		action: #openChannelList.
	channelListButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'channel list'.
	column addMorphBack: channelListButton.

	self addMorph: column frame: (0@0 extent: 0.4@0.8).

	consoleText _ Text new.

	consoleView _ PluggableTextMorph on: self  text: #consoleText accept: nil readSelection: #consoleTextSelection menu: nil.
	self addMorph: consoleView frame: (0.4@0 extent: 0.6@0.8).
	consoleView color: (Color r: 0.937 g: 0.937 b: 0.937).

	inputPane _ PluggableTextMorph on: self text: nil accept: #sendCommand:.
	self addMorph: inputPane frame: (0@0.8 corner: 1@1).