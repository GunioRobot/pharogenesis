initialize
	"initialize the state of the receiver"
	| aFont aForm |
	super initialize.
	""
	
	openForEditing _ false.
	aFont _ Preferences standardButtonFont.
	self addMorph: (prevButton _ SimpleButtonMorph new borderWidth: 0;
					 label: '<' font: aFont;
					 color: Color transparent;
					 setBalloonText: 'previous page';
					 actionSelector: #previousPage;
					 target: self;
					 extent: 16 @ 16).
	self addMorph: (nextButton _ SimpleButtonMorph new borderWidth: 0;
					 label: '>' font: aFont;
					 color: Color transparent;
					 setBalloonText: 'next page';
					 actionSelector: #nextPage;
					 target: self;
					 extent: 16 @ 16).
	menuButton _ ThreePhaseButtonMorph new onImage: (aForm _ ScriptingSystem formAtKey: 'OfferToUnlock');
				
				offImage: (ScriptingSystem formAtKey: 'OfferToLock');
				
				pressedImage: (ScriptingSystem formAtKey: 'OfferToLock');
				 extent: aForm extent;
				 state: #on.
	menuButton target: self;
		 actionSelector: #toggleStatus;
		 actWhen: #buttonUp.
	menuButton setBalloonText: 'open for editing'.
	self addMorph: menuButton.
	" 
	self addMorph: (menuButton _ SimpleButtonMorph new  
	borderWidth: 0;  
	label: '·' font: aFont; color: Color transparent;  
	actWhen: #buttonDown;  
	actionSelector: #invokePartsWindowMenu; target: self; extent:  
	16@16)."
	self adjustBookControls