blueButtonText: aString textColor: textColor inWindow: window

	^(window fancyText: aString translated ofSize: 15 color: textColor)
		setProperty: #buttonText toValue: aString;
		hResizing: #rigid;
		extent: 100@20;
		layoutInset: 4;
		borderWidth: 0;
		useRoundedCorners
