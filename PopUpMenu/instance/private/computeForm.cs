computeForm
	"Compute and answer a Form to be displayed for this menu."

	| borderInset paraForm menuForm |
	borderInset _ 2@2.
	paraForm _ self computeLabelParagraph asForm.
	menuForm _ Form extent: paraForm extent + (borderInset * 2).
	menuForm fillBlack.
	paraForm displayOn: menuForm at: borderInset.
	lineArray == nil ifFalse: [
		lineArray do: [ :line |
			menuForm fillBlack:
				(0 @ ((line * font height) + borderInset y) extent: (menuForm width @ 1)).
		].
	].
	^ menuForm
