pvtBuildFirstGUIRow
	"Build the first complex line of the addressbook gui."
	| collectButton buttonsList newContact searchStringBox freqFilter |

	buttonsList _AlignmentMorph newRow.

	"Set-up the complex search box with a label"
	buttonsList addMorphBack: ((StringMorph contents: 'Search for:') emphasis: 1) ; addTransparentSpacerOfSize: 2 @ 0.
	searchStringBox _ PluggableTextMorph on: self
					text: #searchString accept: #searchString:notifying:
					readSelection: nil menu: nil.
	searchStringBox hResizing: #spaceFill;
		 vResizing: #spaceFill; 
		 setBalloonText: 'Type here a fragment to search for and then push enter. I will do the rest'.
	searchStringBox setProperty: #alwaysAccept toValue: true.
	searchStringBox askBeforeDiscardingEdits: false ;  acceptOnCR: true;  setTextColor: Color brown.
	searchStringBox hideScrollBarIndefinitely; setTextMorphToSelectAllOnMouseEnter.

	buttonsList addMorphBack: searchStringBox.




	freqFilter _ PluggableButtonMorph
				on: self
				getState: #freqFilterState 
				action: #toggleFreqFilterState.
	freqFilter hResizing: #shrinkWrap; vResizing: #spaceFill;
		 label: ' Sort By Freq ' ; useRoundedCorners; 
		setBalloonText: ' Order the elements by the frequency (descending)';
		onColor: Color red offColor: Color white.
	buttonsList addMorphBack: freqFilter ; addTransparentSpacerOfSize: 3 @ 0.


	newContact _ PluggableButtonMorph
				on: self
				getState: nil 
				action: #addNewContact.
	newContact hResizing: #shrinkWrap; vResizing: #spaceFill;
		 label: ' New ' ; useRoundedCorners; 
		setBalloonText: 'Creates a new contact'.
	buttonsList addMorphBack: newContact ; addTransparentSpacerOfSize: 3 @ 0.


	
	collectButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: #findEmails.
	collectButton hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 label: 'Get addresses from Celeste'; useRoundedCorners; 
		 setBalloonText: 'Discover all possible emails address';
		 onColor: Color white offColor: Color white.
	buttonsList addMorphBack: collectButton ; addTransparentSpacerOfSize: 3 @ 0.

	^buttonsList
