newScriptingSpace
	"Answer a complete scripting space"

	| aTemplate  palette aPlayfield aWindow itsModel |
	aWindow _ (SystemWindow labelled: 'scripting area') model: (itsModel _ ScriptingDomain new).
	aWindow setStripeColorsFrom: itsModel defaultBackgroundColor.
	aWindow extent: 640 @ 480.
	aTemplate _ PasteUpMorph new setNameTo: 'etoy'.
	aTemplate extent: 638 @ 470.
	aWindow addMorph: aTemplate frame: (0@0 corner: 1@1).
	aTemplate setStandardTexture.
	aTemplate impartPrivatePresenter; setProperty: #automaticPhraseExpansion toValue: true; beSticky.
	aTemplate presenter addStopStepGoButtons; addTrashCan.

	palette _ TabbedPalette new pageSize: 200@320.
	palette beSticky; useRoundedCorners.
	aTemplate addMorph: palette.
	palette addMenuTab.
	palette addPartsTab.
	palette addControlsTab.
	palette addTilesTab.
	palette selectTabNamed: 'supplies'.
	palette becomeStandardPalette.
	aPlayfield _ PasteUpMorph new setNameTo: 'playfield'.
	aPlayfield useRoundedCorners.
	(Preferences valueOfFlag: #eToyScheme)  "Not widely advertised"
		ifFalse:	
			[aPlayfield setToAdhereToEdge: #topRight.
			palette setToAdhereToEdge: #topLeft]
		ifTrue:
			[aPlayfield setToAdhereToEdge: #topLeft.
			palette setToAdhereToEdge: #topRight].

	aTemplate addMorph: aPlayfield.
	aPlayfield extent: 340@300; position: aTemplate topRight - (400@0).
	aPlayfield beSticky.
	aPlayfield automaticViewing: true.
	aPlayfield wantsMouseOverHalos: true.
	aTemplate presenter standardPlayfield: aPlayfield.
	
	^ aWindow

