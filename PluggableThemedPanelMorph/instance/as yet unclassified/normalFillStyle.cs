normalFillStyle
	"Return the normal fillStyle of the receiver."
	
	UITheme ifNil: [^self paneColor].
	^self theme buttonPanelNormalFillStyleFor: self