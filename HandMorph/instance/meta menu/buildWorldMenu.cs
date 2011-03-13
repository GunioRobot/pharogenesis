buildWorldMenu
	"Build the meta menu for the world."
	| menu subMenu |
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	Project current isTopProject ifFalse:
		[menu add: 'exit this world' action: #exitWorld.
		menu addLine].
	menu add: 'paste morph' action: #pasteMorph.
	menu add: 'new morph...' action: #newMorph.

	World ifNotNil: [
		subMenu _ MenuMorph new defaultTarget: self.
		subMenu add: 'workspace' action: #openWorkspace.
		subMenu add: 'browser' action: #openBrowser.
		subMenu add: 'recent changes' action: #openRecentChanges.
		subMenu add: 'change sorter' action: #openChangeSorter.
		subMenu add: 'changes log' action: #openChangesLog.
		subMenu add: 'file list' action: #openFileList.
		subMenu add: 'transcript' action: #openTranscript.
		subMenu add: 'project (mvc)' action: #openMVCProject.
		subMenu add: 'project (morphic)' action: #openMorphicProject.
		subMenu add: 'project link...' action: #projectThumbnail.
		subMenu addLine.
		subMenu add: 'collapse all' action: #collapseAll.
		subMenu add: 'expand all' action: #expandAll.
		subMenu add: 'find window' action: #findWindow.
		menu add: 'windows...' subMenu: subMenu].

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'grab drawing from screen' action: #grabDrawingFromScreen.
	subMenu add: 'read drawing from file' action: #importImageFromDisk.
	subMenu add: 'make new drawing' target: self presenter associatedMorph action: #makeNewDrawingWithin.
	menu add: 'graphics...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'add slot to model' action: #newVariable.
	subMenu add: 'write init method for model' action: #writeInitMethodForModel.
	subMenu add: 'grab model for this world' action: #grabModel.
	menu add: 'model...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'set display depth...' action: #setDisplayDepth.
	subMenu add: 'change background color' action: #changeBackgroundColor.
	subMenu add: 'use texture background' target: self world action: #setStandardTexture.
	subMenu add: 'unlock contents' action: #unlockWorldContents.
	subMenu add: 'unhide hidden objects' action: #showHiders.
	subMenu add: 'round up stray objects' action: #roundUpStrayObjects.
	gridOn
		ifTrue: [subMenu add: 'turn gridding off' action: #setGridding]
		ifFalse: [subMenu add: 'turn gridding on' action: #setGridding].
	menu add: 'options...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'update code from server' action: #updateFromServer.
	subMenu addLine.
	subMenu add: 'local host address' action: #reportLocalAddress.
	subMenu add: 'connect remote user' action: #connectRemoteUser.
	subMenu add: 'disconnect remote user' action: #disconnectRemoteUser.
	subMenu add: 'disconnect all remote users' action: #disconnectAllRemoteUsers.
	menu add: 'remote...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'read drawing from file' action: #importImageFromDisk.
	subMenu add: 'save world in file' action: #saveWorldInFile.
	subMenu add: 'read morph(s) from file' action: #readMorphFile.
	menu add: 'file...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self world.
	subMenu add: 'add stop, step, & go buttons' target: self world presenter action: #addStopStepGoButtons.
	subMenu add: 'add scripting knobs' target: self presenter action: #addStandardControls.
	subMenu add: 'remove scripting knobs' target: self world action: #removeScriptingControls.
	subMenu addLine.
	subMenu add: 'parts bin' target: self presenter action: #createStandardPartsBin.
	subMenu add: 'control panel' target: self presenter action: #createControlPanel.
	menu add: 'scripting...' subMenu: subMenu.

	menu add: 'do...' target: Utilities action: #offerCommonRequests.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'inspect world' action: #inspectWorld.
	subMenu add: 'inspect model' action: #inspectWorldModel.
	subMenu add: 'clear palette area' action: #clearPaletteArea.
	subMenu add: 'flush viewer cache' action: #flushViewerCache.
	subMenu add: 'full screen' action: #fullScreen.
	subMenu add: 'start MessageTally' action: #startMessageTally.
	subMenu add: 'call #tempCommand' action: #callTempCommand.
	subMenu add: 'show space left' action: #showSpaceLeft.
	menu add: 'debug...' subMenu: subMenu.

	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'save' action: #saveSession.
	subMenu add: 'save as...' action: #saveAs.
	subMenu add: 'save and quit' action: #saveAndQuit.
	subMenu add: 'quit...' action: #quitSession.
	menu add: 'save / quit...' subMenu: subMenu.

	^ menu