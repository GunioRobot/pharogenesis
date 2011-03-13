model: anObject
	"Set the model."
	
	super model: anObject.
	self paneColorTracksModel ifTrue: [
		self
			setProperty: #paneColor toValue: self defaultBackgroundColor;
			fillStyle: self fillStyleToUse;
			setStripeColorsFrom: self paneColorToUse.
		Preferences fadedBackgroundWindows ifFalse: [ "since not done in stripes"
			self adoptPaneColor: self paneColor]].
	self minimumExtent: (
		(anObject respondsTo: #minimumExtent)
			ifTrue: [anObject minimumExtent]).
	menuBox ifNotNil: [
		menuBox
			labelGraphic: (self theme windowMenuIconFor: self);
			extent: self boxExtent]