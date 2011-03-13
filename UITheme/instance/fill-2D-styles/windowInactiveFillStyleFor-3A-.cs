windowInactiveFillStyleFor: aWindow
	"Return the window inactive fillStyle for the given window."
	
	^Preferences fadedBackgroundWindows
		ifTrue: [aWindow paneColorToUse
					alphaMixed: 0.9
					with: (Color white alpha: aWindow paneColorToUse alpha)]
		ifFalse: [aWindow paneColorToUse]