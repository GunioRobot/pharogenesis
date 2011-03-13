initializeFor: aPlayer categoryChoice: aChoice
	"Initialize the receiver to be associated with the player and category specified"

	self listDirection: #topToBottom;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		borderWidth: 1;
		beSticky.
	self color: Color green muchLighter muchLighter.
	scriptedPlayer _ aPlayer.
	self addHeaderMorph.

	self categoryChoice: aChoice asSymbol
