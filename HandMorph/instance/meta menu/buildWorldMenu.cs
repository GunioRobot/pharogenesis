buildWorldMenu
	"Build the meta menu for the world."
	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	Project current isTopProject ifFalse:
		[menu add: 'exit this world' action: #exitWorld.
		menu addLine].
	menu add: 'new morph' action: #newMorph.
	menu add: 'read morph(s) from file' action: #readMorphFile.
	menu addLine.
	menu add: 'new drawing' action: #makeNewDrawing.
	menu add: 'grab drawing from screen' action: #grabDrawingFromScreen.
	menu add: 'read drawing from file' action: #importImageFromDisk.
	menu addLine.
	menu add: 'change background color' action: #changeBackgroundColor.
	menu add: 'inspect world' action: #inspectWorld.
	menu addLine.
		menu add: 'save world in file' action: #saveWorldInFile.
	menu addLine.
	menu add: 'add slot to model' action: #newVariable.
	menu add: 'write init method for model' action: #writeInitMethodForModel.
	menu add: 'grab model for this world' action: #grabModel.
	gridOn
		ifTrue: [menu add: 'turn gridding off' action: #setGridding]
		ifFalse: [menu add: 'turn gridding on' action: #setGridding].
	menu addLine.
	menu add: 'local host address' action: #reportLocalAddress.
	menu add: 'connect remote user' action: #connectRemoteUser.
	menu add: 'disconnect remote user' action: #disconnectRemoteUser.
	menu add: 'disconnect all remote users' action: #disconnectAllRemoteUsers.
	^ menu
