openMorphicView
	| win descListView updateButton actionColumn openChannelButton createChannelButton |
	win _ SystemWindow new.
	win setLabel: 'Channel Listing'.
	win model: self.

	descListView _ PluggableListMorph on: self  list: #channelDescriptions selected: #channelIndex changeSelected: #channelIndex:.
	win addMorph: descListView  frame: (0@0 extent: 0.8@0.9).

	updateButton _ PluggableButtonMorph on: connection getState: nil action: #requestChannelList.
	updateButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'update'.
	win addMorph: updateButton  frame: (0@0.9 extent: 1@0.1).


	actionColumn _ AlignmentMorph newColumn.

	openChannelButton _ PluggableButtonMorph on: self getState: nil action: #openSelectedChannel.
	openChannelButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'join channel'.
	actionColumn addMorphBack: openChannelButton.

	createChannelButton _ PluggableButtonMorph on: self getState: nil action: #createChannel.
	createChannelButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'create channel'.
	actionColumn addMorphBack: createChannelButton.

	win addMorph: actionColumn  frame: (0.8@0 extent: 0.2@0.9).

	win openInWorld