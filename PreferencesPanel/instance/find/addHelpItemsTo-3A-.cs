addHelpItemsTo: panelPage
	"Add the items appropriate the the ? page of the receiver"

	| aButton aTextMorph aMorph firstTextMorph |
	panelPage hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	firstTextMorph _  TextMorph new contents: 'Search Preferences for:'.
	firstTextMorph beAllFont: ((TextStyle default fontOfSize: 13) emphasized: 1).
	panelPage addMorphBack: firstTextMorph lock.
	panelPage addTransparentSpacerOfSize: 0@10.

	aMorph _ RectangleMorph new clipSubmorphs: true; beTransparent; borderWidth: 2; borderColor: Color black; extent: 250 @ 36.
	aMorph vResizing: #rigid; hResizing: #rigid.
	aTextMorph _  PluggableTextMorph new
				on: self
				text: #searchString
				accept: #setSearchStringTo:
				readSelection: nil
				menu: nil.
"	aTextMorph hResizing: #rigid."
	aTextMorph borderWidth: 0.
	aTextMorph font: ((TextStyle default fontOfSize: 21) emphasized: 1); setTextColor: Color red.
	aMorph addMorphBack: aTextMorph.
	aTextMorph acceptOnCR: true.
	aTextMorph position: (aTextMorph position + (6@5)).
	aMorph clipLayoutCells: true.
	aTextMorph extent: 240 @ 25.
	panelPage addMorphBack: aMorph.
	aTextMorph setBalloonText: 'Type what you want to search for here, then hit the "Search" button, or else hit RETURN or ENTER'.
	aTextMorph setTextMorphToSelectAllOnMouseEnter.
	aTextMorph hideScrollBarsIndefinitely.
	panelPage addTransparentSpacerOfSize: 0@10.

	aButton _ SimpleButtonMorph new target: self; color: Color transparent; actionSelector: #initiateSearch:; arguments: {aTextMorph}; label: 'Search'.
	panelPage addMorphBack: aButton.
	aButton setBalloonText: 'Type what you want to search for in the box above, then click here (or hit RETURN or ENTER) to start the search; results will appear in the "search results" category.'.

	panelPage addTransparentSpacerOfSize: 0@30.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 'Restore all Default Preference Settings'; target: Preferences; actionSelector: #chooseInitialSettings; setBalloonText: 'Click here to reset all the preferences to their standard default values.'; yourself).

	panelPage addTransparentSpacerOfSize: 0@14.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 
'Save Current Settings as my Personal Preferences'; 
		target: Preferences; actionSelector: #savePersonalPreferences; setBalloonText: 'Click here to save the current constellation of Preferences settings as your personal defaults; you can get them all reinstalled with a single gesture by clicking the "Restore my Personal Preferences".'; yourself).

	panelPage addTransparentSpacerOfSize: 0@14.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 'Restore my Personal Preferences'; target: Preferences; actionSelector: #restorePersonalPreferences; setBalloonText: 'Click here to reset all the preferences to their values in your Personal Preferences.'; yourself).

	panelPage addTransparentSpacerOfSize: 0@30.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 
'Save Current Settings to Disk'; 
		target: Preferences; actionSelector: #storePreferencesToDisk; setBalloonText: 'Click here to save the current constellation of Preferences settings to a file; you can get them all reinstalled with a single gesture by clicking "Restore Settings From Disk".'; yourself).

	panelPage addTransparentSpacerOfSize: 0@14.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 'Restore Settings from Disk'; target: Preferences; actionSelector: #restorePreferencesFromDisk; setBalloonText: 'Click here to load all the preferences from their saved values on disk.'; yourself).

	panelPage addTransparentSpacerOfSize: 0@30.

	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 'Inspect Parameters'; target: Preferences; actionSelector: #inspectParameters; setBalloonText: 'Click here to view all the values stored in the system Parameters dictionary'; yourself).

	panelPage addTransparentSpacerOfSize: 0@10.
	panelPage addMorphBack: (Preferences themeChoiceButtonOfColor: Color transparent font: TextStyle defaultFont).
	panelPage addTransparentSpacerOfSize: 0@10.
	panelPage addMorphBack: (SimpleButtonMorph new color: Color transparent; label: 'Help!'; target: Preferences; actionSelector: #giveHelpWithPreferences; setBalloonText: 'Click here to get some hints on use of this Preferences Panel'; yourself).
	panelPage wrapCentering: #center.
