createCollapseBoxFor: aSystemWindow
	"Answer a button for minimising the window."
	
	^aSystemWindow createBox
		labelGraphic: self windowMinimizeForm;
		extent: aSystemWindow boxExtent;
		actionSelector: #collapseBoxHit;
		setBalloonText: 'collapse this window' translated