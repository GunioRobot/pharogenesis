dialogWindowActiveFillStyleFor: aWindow
	"Return the dialog window active fillStyle for the given window."
	
	^(BitmapFillStyle fromForm: self stripesForm)
		origin: aWindow topLeft