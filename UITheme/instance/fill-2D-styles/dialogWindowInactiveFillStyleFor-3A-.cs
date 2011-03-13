dialogWindowInactiveFillStyleFor: aWindow
	"Return the dialog window inactive fillStyle for the given window."
	
	^Preferences fadedBackgroundWindows
		ifTrue: [aWindow paneColorToUse lighter
					alphaMixed: 0.9
					with: (Color white alpha: aWindow paneColorToUse alpha)]
		ifFalse: [aWindow paneColorToUse lighter]