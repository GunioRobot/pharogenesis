assurePauseTickControlsShow
	"Add two little buttons that allow the user quickly to toggle between paused and ticking state"

	| aButton |
	tickPauseButtonsShowing ifTrue: [^ self].
	self beTransparent.
	aButton _  UpdatingThreePhaseButtonMorph new.
	aButton image:  (ScriptingSystem formAtKey: 'PausedPicOn');
			offImage: (ScriptingSystem formAtKey: 'PausedPicOff');
			pressedImage: (ScriptingSystem formAtKey: 'PausedPicPressed');
			actionSelector: #pausedUp:with:; 
			arguments: (Array with: nil with: aButton);
			getSelector: #scriptIsPaused;
			actWhen: #buttonUp;
			target: self;
			setBalloonText:
'Pause this script for this object'.
	submorphs first "the script button wrapper" addMorphBack: aButton;
		addTransparentSpacerOfSize: (0 @ 3).
	aButton _  UpdatingThreePhaseButtonMorph new.
	aButton image:  (ScriptingSystem formAtKey: 'TickingPicOn');
			offImage: (ScriptingSystem formAtKey: 'TickingPicOff');
			pressedImage: (ScriptingSystem formAtKey: 'TickingPicPressed');
			actionSelector: #tickingUp:with:; 
			arguments: (Array with: nil with: aButton);
			actWhen: #buttonUp;
			getSelector: #scriptIsTicking;
			target: self;
			setBalloonText:
'Set this script for this object to tick'.
	submorphs first "the script button wrapper" addMorphBack: aButton.
	self currentWorld startSteppingSubmorphsOf: self.
	tickPauseButtonsShowing _ true