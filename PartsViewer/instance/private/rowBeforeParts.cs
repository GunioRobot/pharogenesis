rowBeforeParts
	| r nail aButton aTextMorph aFont |

	r _ AlignmentMorph newRow color: self color; centering: #center.
	aFont _ ScriptingSystem fontForScriptorButtons.
	r addMorph: (aButton _ SimpleButtonMorph new label: 'X' font: aFont).
	aButton target: self;
			color:  Color lightRed;
			actionSelector: #delete;
			setBalloonText: 'Hit the X to remove this Viewer'.
	r addTransparentSpacerOfSize: 5@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #previousPartsBank; label: '<' font: aFont; color: self caretColor; borderWidth: 0; actWhen: #buttonUp.
	r addMorphBack: aButton.
	aButton setBalloonText: 'Show previous bank of parts'.	
	r addTransparentSpacerOfSize: 5@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #nextPartsBank; label: '>' font: aFont; color: self caretColor; borderWidth: 0; actWhen: #buttonUp.
	aButton setBalloonText: 'Show next bank of parts'.	
	r addMorphBack: aButton.
	r addTransparentSpacerOfSize: 7@5.

	scriptedPlayer assureExternalName.
	aTextMorph _ UpdatingStringMorph new
		useStringFormat;
		target:  scriptedPlayer;
		getSelector: #getName;
		putSelector: #setName:;
		setNameTo: 'name';
		font: ScriptingSystem fontForNameEditingInScriptor.
	aTextMorph setProperty: #okToTextEdit toValue: true.
	r  addMorphBack: aTextMorph.
	aTextMorph setBalloonText: 'Click here to edit the player''s name
use backspace to delete unwanted characters'.	
	r addTransparentSpacerOfSize: 5@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #previousCostume; label: '<' font: aFont; color: Color veryLightGray; borderWidth: 0; actWhen: #buttonUp.
	r addMorphBack: aButton.
	aButton setBalloonText: 'switch to previous costume'.	
	r addTransparentSpacerOfSize: 5@5.

	aButton _ SimpleButtonMorph new target: self; actionSelector: #nextCostume; label: '>' font: aFont; color: Color veryLightGray; borderWidth: 0; actWhen: #buttonUp.
	r addMorphBack: aButton.
	aButton setBalloonText: 'switch to next costume'.
	r addTransparentSpacerOfSize: 10@5.

	nail _ ThumbnailMorph new objectToView: scriptedPlayer viewSelector: #costume.
	nail on: #mouseDown send: #newCostume to: scriptedPlayer.
	r addMorphBack: nail.
	nail setBalloonText: 'click here to specify new costume.'.	
	^ r
