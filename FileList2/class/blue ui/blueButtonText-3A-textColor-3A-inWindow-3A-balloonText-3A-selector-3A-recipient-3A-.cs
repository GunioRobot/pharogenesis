blueButtonText: aString textColor: textColor inWindow: window balloonText: balloonText selector: sel recipient: recip

	^(window fancyText: aString translated ofSize: 15 color: textColor)
		setProperty: #buttonText toValue: aString;
		hResizing: #rigid;
		extent: 100@20;
		layoutInset: 4;
		borderWidth: 0;
		useRoundedCorners;
		setBalloonText: balloonText;
		on: #mouseUp send: sel to: recip
