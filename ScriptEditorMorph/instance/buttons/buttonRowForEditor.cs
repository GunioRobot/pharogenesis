buttonRowForEditor
	"Answer a row of buttons that comprise the header at the top of the Scriptor"

	| aRow aString buttonFont aStatusMorph aButton aColumn aTile |
	buttonFont _ Preferences standardButtonFont.
	aRow _ AlignmentMorph newRow color: Color transparent; layoutInset: 0.
	aRow hResizing: #shrinkWrap.
	aRow vResizing: #shrinkWrap.
	self hasParameter ifFalse:
		[aRow addMorphFront:
			(SimpleButtonMorph new
				label: '!' font: Preferences standardEToysFont;
				target: self;
				color: Color yellow;
				borderWidth: 0;
				actWhen: #whilePressed;
				actionSelector: #tryMe;
				balloonTextSelector: #tryMe).
		aRow addTransparentSpacerOfSize: 6@10].
	self addDismissButtonTo: aRow.
	aRow addTransparentSpacerOfSize: 6@1.
	aColumn _ AlignmentMorph newColumn beTransparent.
	aColumn addTransparentSpacerOfSize: 0@4.
	aButton _ UpdatingThreePhaseButtonMorph checkBox.
	aButton
		target: self;
		actionSelector: #toggleWhetherShowingTiles;
		getSelector: #showingMethodPane.
	aButton setBalloonText: 'toggle between showing tiles and showing textual code' translated.
	aColumn addMorphBack: aButton.
	aRow addMorphBack: aColumn.

	aRow addTransparentSpacerOfSize: 6@10.

	aString _ playerScripted externalName.
	aRow addMorphBack:
		(aButton _ SimpleButtonMorph new useSquareCorners label: aString font: buttonFont; target: self; setNameTo: 'title').
	aButton actWhen: #buttonDown; actionSelector: #offerScriptorMenu.
	aButton
		on: #mouseEnter send: #menuButtonMouseEnter: to: aButton;
		on: #mouseLeave send: #menuButtonMouseLeave: to: aButton.

	aButton borderColor: (Color fromRgbTriplet: #(0.065 0.258 1.0)).
	aButton color: ScriptingSystem uniformTileInteriorColor.
	aButton balloonTextSelector: #offerScriptorMenu.
	aRow addTransparentSpacerOfSize: 4@1.
	aButton _ (Preferences universalTiles ifTrue: [SyntaxUpdatingStringMorph] 
					ifFalse: [UpdatingStringMorph]) new.
	aButton useStringFormat;
		target:  self;
		getSelector: #scriptTitle;
		setNameTo: 'script name';
		font: ScriptingSystem fontForNameEditingInScriptor;
		putSelector: #setScriptNameTo:;
		setProperty: #okToTextEdit toValue: true;
		step;
		yourself.
	aRow addMorphBack: aButton.
	aButton setBalloonText: 'Click here to edit the name of the script.' translated.
	aRow addTransparentSpacerOfSize: 6@0.
	self hasParameter
		ifTrue:
			[aTile _ TypeListTile new choices: Vocabulary typeChoices dataType: nil.
			aTile addArrows.
			aTile setLiteral: #Number.
	"(aButton _ SimpleButtonMorph new useSquareCorners label: 'parameter' translated font: buttonFont; target: self; setNameTo: 'parameter').
			aButton actWhen: #buttonDown; actionSelector: #handUserParameterTile.

"
			aRow addMorphBack: aTile.
			aTile borderColor: Color red.
			aTile color: ScriptingSystem uniformTileInteriorColor.
			aTile setBalloonText: 'Drag from here to get a parameter tile' translated]
		ifFalse:
			[aRow addMorphBack: (aStatusMorph _ self scriptInstantiation statusControlMorph)].

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
	(playerScripted existingScriptInstantiationForSelector: scriptName)
		ifNotNilDo:
			[:inst | inst updateStatusMorph: aStatusMorph].
	^ aRow