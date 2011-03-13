buttonRowForEditor
	"Answer a row of buttons that comprise the header at the top of the Scriptor"

	| aRow aString aButtonMorph buttonFont aStatusMorph aButton aColumn |
	buttonFont _ Preferences standardButtonFont.
	aRow _ AlignmentMorph newRow color: Color transparent; layoutInset: 0.
	aRow hResizing: #shrinkWrap.
	aRow vResizing: #shrinkWrap.

	aRow addMorphFront:
		(SimpleButtonMorph new
			label: '!' font: (StrikeFont familyName: #ComicBold size: 16);
			target: self;
			color: Color yellow;
			borderWidth: 0;
			actWhen: #whilePressed;
			actionSelector: #tryMe;
			balloonTextSelector: #tryMe).
	aRow addTransparentSpacerOfSize: 6@10.
	self addDismissButtonTo: aRow.
	aRow addTransparentSpacerOfSize: 6@1.
	aColumn _ AlignmentMorph newColumn beTransparent.
	aColumn addTransparentSpacerOfSize: 0@4.
	aButton _ UpdatingThreePhaseButtonMorph checkBox.
	aButton
		target: self;
		actionSelector: #toggleWhetherShowingTiles;
		getSelector: #showingMethodPane.
	aButton setBalloonText: 'toggle between showing tiles and showing textual code'.
	aColumn addMorphBack: aButton.
	aRow addMorphBack: aColumn.

	aRow addTransparentSpacerOfSize: 6@10.

	aString _ playerScripted externalName, ' ', self scriptTitle.
	aRow addMorphBack:
		(aButtonMorph _ SimpleButtonMorph new useSquareCorners label: aString font: buttonFont; target: self; setNameTo: 'title').
	aButtonMorph actWhen: #buttonDown; actionSelector: #offerScriptorMenu.
	aButtonMorph borderColor: (Color fromRgbTriplet: #(0.065 0.258 1.0)).
	aButtonMorph color: ScriptingSystem uniformTileInteriorColor.
	aButtonMorph balloonTextSelector: #offerScriptorMenu.
	aRow addMorphBack: (aStatusMorph _ self scriptInstantiation statusControlMorph).

	aRow addTransparentSpacerOfSize: 6@1.

	aRow addMorphBack:
		(IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: 'AddTest'); color: Color transparent; 
			actWhen: #buttonDown;
			target: self;
			actionSelector: #addYesNoToHand;
			shedSelvedge;
			balloonTextSelector: #addYesNoToHand).
	aRow addTransparentSpacerOfSize: 12@10.
	self addDestroyButtonTo: aRow.
	self scriptInstantiation updateStatusMorph: aStatusMorph.
	^ aRow