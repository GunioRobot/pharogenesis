buildPreferenceTabbedPalette: aModel
	| aTabbedPalette exportPane aFont userPrefPane buttons btn defaultTab |
	"See Preferences class >>initializePreferencePanel: aPanel in: aPasteUpMorph and
	  TabbedPalette>> authoringPrototype"
	aTabbedPalette := TabbedPalette newSticky.
	aTabbedPalette  dropEnabled: false; pageSize: 300 @ 200.
	aTabbedPalette tabsMorph highlightColor: Color red regularColor: Color blue.
	"Hmm... what exactly do this ? [gg]"
	aTabbedPalette on: #mouseDown send: #yourself to: #().
	



	aFont := StrikeFont familyName: 'Accujen' size: 18.
	

	userPrefPane := AlignmentMorph newColumn 
				 layoutInset: 0;
				 borderWidth: 1;
				 borderColor: Color black;
				 layoutPolicy: TableLayout new.
	userPrefPane beSticky;
		 wrapCentering: #center;
		 cellPositioning: #leftCenter; 
		 clipSubmorphs: true; addTransparentSpacerOfSize: 5 @ 5.
	userPrefPane  setNameTo:'User Profiles'.
	

	
	buttons := #(			
		#(nil #readSetup  ''
				'Load the default settings')
	).
	(buttons at:1) at:3 put: 'Load default settings:' , (aModel settingsFileName asString).
	
	buttons do:[:spec|				
		btn := self buildButtonFromSpec: spec forModel: aModel.
		userPrefPane  addMorphBack: btn.
		userPrefPane addTransparentSpacerOfSize: 3 @ 0.
	].

	defaultTab := aTabbedPalette addTabFor: userPrefPane font: aFont.



	exportPane :=  AlignmentMorph newColumn 
				 layoutInset: 0;
				 borderWidth: 1;
				 borderColor: Color black;
				 layoutPolicy: TableLayout new.
				
	exportPane beSticky;
		 wrapCentering: #center;
		 cellPositioning: #leftCenter.
	exportPane clipSubmorphs: true.
	exportPane addTransparentSpacerOfSize: 5 @ 5.
	
	exportPane  setNameTo: 'DB Management/Export'.
	exportPane color: Color blue muchLighter.	
	

	self buildPreferenceExportPane: exportPane onModel: aModel.
	aTabbedPalette addTabFor: exportPane font: aFont.
	
	aTabbedPalette selectTab: defaultTab.
	aTabbedPalette beSticky.
	aTabbedPalette tabsMorph hResizing: #spaceFill.
	aTabbedPalette addMenuTab.
	^ aTabbedPalette