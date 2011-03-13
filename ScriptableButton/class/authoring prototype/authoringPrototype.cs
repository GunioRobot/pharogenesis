authoringPrototype
	"Answer a scriptable button that can serve as a prototype for a parts bin"

	^ super authoringPrototype
		borderWidth: 1;
		borderColor: Color black;
		useRoundedCorners;
		color: Color yellow;
		label: 'Press me';
		setNameTo: 'script1';
		yourself

"ScriptableButton authoringPrototype openInHand"