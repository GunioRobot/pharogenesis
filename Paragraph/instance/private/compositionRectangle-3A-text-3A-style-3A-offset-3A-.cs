compositionRectangle: compositionRect text: aText style: aTextStyle offset: aPoint

	compositionRectangle := compositionRect copy.
	text := aText.
	textStyle := aTextStyle.
	rule := DefaultRule.
	mask := nil.		"was DefaultMask "
	marginTabsLevel := 0.
	destinationForm := Display.
	offset := aPoint.
	^self composeAll