paneColor: aColor
	self setProperty: #paneColor toValue: aColor.
	(Preferences alternativeWindowLook and:[aColor notNil]) 
		ifTrue:[self color: aColor veryMuchLighter].
	self adoptPaneColor: aColor.