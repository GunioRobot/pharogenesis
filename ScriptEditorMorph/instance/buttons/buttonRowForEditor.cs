buttonRowForEditor
	| r aString aButtonMorph buttonFont aStatusMorph aStatus |
	buttonFont _ Preferences standardButtonFont.
	r _ AlignmentMorph newRow color: Color transparent; inset: 0.

	r addMorphFront:
		(SimpleButtonMorph new
			label: '!' font: (StrikeFont familyName: #ComicBold size: 16);
			target: self;
			color: Color yellow;
			borderWidth: 0;
			actWhen: #whilePressed;
			actionSelector: #tryMe;
			balloonTextSelector: #tryMe).
	r addTransparentSpacerOfSize: 6@10.

	aString _ playerScripted externalName, ' ', self scriptTitle.
	r addMorphBack:
		(aButtonMorph _ SimpleButtonMorph new useSquareCorners label: aString font: buttonFont; target: self; setNameTo: 'title').
	aButtonMorph actWhen: #buttonDown; actionSelector: #offerScriptorMenu.
	aButtonMorph borderColor: (Color fromRgbTriplet: #(0.065 0.258 1.0)).
	aButtonMorph color: (self isAnonymous ifTrue: [Color blue muchLighter] ifFalse: [ScriptingSystem uniformTileInteriorColor]).
	aButtonMorph balloonTextSelector: #offerScriptorMenu.
	r addTransparentSpacerOfSize: 6@10.

	aStatus _ self scriptInstantiation status.
	r addMorphBack:
			(aStatusMorph _ SimpleButtonMorph new useSquareCorners label: aStatus font: buttonFont;
				setNameTo: 'trigger';
				target: self;
				actWhen: #buttonDown;
				actionSelector: #chooseTrigger;
				setBalloonText: (ScriptingSystem helpStringFor: #chooseTrigger) maxLineLength: 65;
				balloonTextSelector: #chooseTrigger).

	r addTransparentSpacerOfSize: 10@10.
	r addMorphBack:
		(IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: 'AddTest'); color: Color transparent; 
			actWhen: #buttonDown;
			target: self;
			actionSelector: #addYesNoToHand;
			shedSelvedge;
			balloonTextSelector: #addYesNoToHand).
	r addTransparentSpacerOfSize: 12@10.
	self addDismissButtonTo: r.
	self updateStatusMorph: aStatusMorph.
	^ r