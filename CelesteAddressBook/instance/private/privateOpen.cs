privateOpen
	"open a Morphic interface for sending a mail message with the given  
	initial text. MVC is unsupported at the moment"
	| buttonsList morphicWindow alertText contactListWidget lastRow prefsButton|
	morphicWindow _ SystemWindow labelled: 'JJ''s CelesteAddressbook'.
	morphicWindow model: self.
	buttonsList _ self pvtBuildFirstGUIRow.
	lastRow _ AlignmentMorph newRow.
	
	statusBar _ StringHolder new.
	statusBar contents: 'Ready'.


	alertText _ PluggableTextMorph
				on: statusBar
				text: #contents
				accept: #acceptContents:.
	alertText hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 setBalloonText: 'Display processing status';
		hideScrollBarIndefinitely.

	prefsButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: #openPreferenceWindow.
	 prefsButton 
		 vResizing: #spaceFill;
		 label: 'Preferences';
		 setBalloonText: 'Set the preferences for the AddressBook'.
	lastRow addMorphBack: (StringMorph contents:'Status:').
	lastRow addMorphBack: alertText.
	lastRow addMorphBack: prefsButton.

	contactListWidget _ (PluggableListMorphByItem
				on: self
				list: #contactList
				selected: #selectedContactItem
				changeSelected: #setSelectedContactItem:
				menu: #contactListMenu:
				keystroke: nil)
				enableDragNDrop: false.
	contactListWidget hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 setBalloonText: 'For Browsing the emails I found for you'.

	"Build the GUI combining large objects,"
	morphicWindow
		addMorph: buttonsList
		frame: (0 @ 0 extent: 1 @ 0.1).
	morphicWindow
		addMorph: contactListWidget
		frame: (0 @ 0.101 extent: 1 @ 0.8).
	morphicWindow
		addMorph: lastRow
		frame: (0 @ 0.9 extent: 1 @ 0.1).
	morphicWindow minimumExtent: 500@300.
	morphicWindow openInMVC