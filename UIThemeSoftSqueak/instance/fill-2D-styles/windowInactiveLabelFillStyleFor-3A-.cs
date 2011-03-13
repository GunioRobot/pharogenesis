windowInactiveLabelFillStyleFor: aWindow
	"Return the window inactive label fillStyle for the given window."
	
	^aWindow paneColorToUse alphaMixed: 0.6 with: Color black