compositionRectangle: compositionRect text: aText style: aTextStyle offset: aPoint

	compositionRectangle _ compositionRect copy.
	text _ aText.
	textStyle _ aTextStyle.
	rule _ DefaultRule.
	mask _ DefaultMask.
	marginTabsLevel _ 0.
	destinationForm _ Display.
	offset _ aPoint.
	^self composeAll