initializeFor: aPhraseTileMorph
	| lm aStatus |
	self playerScripted: aPhraseTileMorph actualObject.
	scriptName _ aPhraseTileMorph userScriptSelector.
	self removeAllMorphs.
	self addMorphFront: (lm _ AlignmentMorph newRow).
	lm color: Color transparent; inset: 0.
	lm vResizing: #shrinkWrap.
	lm addMorphBack: (ScriptingSystem tryButtonFor: aPhraseTileMorph).
	lm addTransparentSpacerOfSize: 6@1.
	lm addMorphBack: aPhraseTileMorph beSticky.
	lm addTransparentSpacerOfSize: 4@1.
	
	aStatus _ (playerScripted scriptInstantiationForSelector: scriptName) status.
	lm addMorphBack:
			(SimpleButtonMorph new label: aStatus font: Preferences standardButtonFont;
				setNameTo: 'trigger';
				target: self;
				actWhen: #buttonDown;
				actionSelector: #chooseTrigger).
	lm addTransparentSpacerOfSize: 4@1.
	self addDismissButtonTo: lm.
	self disableDragNDrop.
	lm enableDragNDrop