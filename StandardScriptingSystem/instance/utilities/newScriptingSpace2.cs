newScriptingSpace2
	"Answer a complete scripting space"

	| aTemplate  aPlayfield aControl |
	
	(aTemplate _ PasteUpMorph new)
		setNameTo: 'etoy';
		extent: 638 @ 470;
		color: Color white;
		impartPrivatePresenter;
		setProperty: #automaticPhraseExpansion toValue: true;
		beSticky.
	aTemplate useRoundedCorners; borderWidth: 2. 
	aControl _  ScriptingSystem scriptControlButtons setToAdhereToEdge: #bottomLeft.
	aControl beSticky; borderWidth: 0; beTransparent.
	aTemplate addMorphBack: aControl.
	aTemplate presenter addTrashCan.

	aTemplate addMorph: (aPlayfield _ PasteUpMorph new).
	aPlayfield
		setNameTo: 'playfield';
		useRoundedCorners;
		setToAdhereToEdge: #topLeft;
		extent: 340@300;
		position: aTemplate topRight - (400@0);
		beSticky;
		automaticViewing: true;
		wantsMouseOverHalos: true.
	aTemplate presenter standardPlayfield: aPlayfield.
	
	^ aTemplate

