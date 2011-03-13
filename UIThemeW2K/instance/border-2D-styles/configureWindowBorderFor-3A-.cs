configureWindowBorderFor: aWindow
	"Configure the border for the given window."

	"aWindow roundedCorners: #(1 2 3 4)"
	| aStyle |
	
	
	aStyle := BorderStyle complexRaised.
	aStyle width: 2.
	aStyle color: self backgroundColor.
	aStyle baseColor: self backgroundColor.

	aWindow borderStyle: aStyle.
	

