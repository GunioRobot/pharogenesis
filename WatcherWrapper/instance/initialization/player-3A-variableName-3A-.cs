player: aPlayer variableName: aVariableName
	"Set up my initial state"

	| aColor |
	aColor _ Color r: 0.387 g: 0.581 b: 1.0.
	player _ aPlayer.
	variableName _ aVariableName.
	self
		listDirection: #leftToRight;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap; 
		color: aColor;
		layoutInset: -1;
		borderWidth: 1;
		borderColor: aColor darker;
		listCentering: #center.
	self reconstituteName
