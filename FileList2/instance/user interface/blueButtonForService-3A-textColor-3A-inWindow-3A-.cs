blueButtonForService: aService textColor: textColor inWindow: window

	| block |
	block _ [ aService performServiceFor: self ] copy fixTemps.
	^(window fancyText: aService buttonLabel capitalized translated ofSize: 15 color: textColor)
		setProperty: #buttonText toValue: aService buttonLabel capitalized;
		hResizing: #rigid;
		extent: 100@20;
		layoutInset: 4;
		borderWidth: 0;
		useRoundedCorners;
		setBalloonText: aService label translated;
		on: #mouseUp send: #value to: block 
