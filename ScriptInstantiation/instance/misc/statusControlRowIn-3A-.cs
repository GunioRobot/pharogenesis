statusControlRowIn: aStatusViewer
	"Answer a row morph that reports my status and lets the user change it"

	| aRow aMorph buttonWithPlayerName |
	aRow _ AlignmentMorph newRow beTransparent.
	buttonWithPlayerName _ UpdatingSimpleButtonMorph new.
	buttonWithPlayerName target: self; wordingSelector: #playersExternalName; actionSelector: #offerMenuIn:; arguments: {aStatusViewer}; beTransparent; actWhen: #buttonDown.
	buttonWithPlayerName setBalloonText: 'This is the name of the player to which this script belongs; if you click here, you will get a menu of interesting options pertaining to this player and script'.
	aRow addMorphBack: buttonWithPlayerName.
	aRow addTransparentSpacerOfSize: 10@0.
	aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.

	aMorph _ UpdatingStringMorph on: self selector: #selector.
	aMorph color: Color brown lighter; useStringFormat.
	aMorph setBalloonText: 'This is the name of a script'.
	aRow addMorphBack: aMorph.
	aRow addMorphBack: AlignmentMorph newVariableTransparentSpacer.
	aRow addTransparentSpacerOfSize: 10@0.

	aRow addMorphBack: self statusControlMorph.
	aRow submorphsDo: [:m | m wantsSteps ifTrue: [m step]].
	^ aRow