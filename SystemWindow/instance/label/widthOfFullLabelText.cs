widthOfFullLabelText
	^ (DisplayScanner quickPrintOn: Display box: Display boundingBox font: (Preferences windowTitleFont emphasized: 1)) stringWidth: labelString