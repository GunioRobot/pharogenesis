enabled: anObject
	"Set the value of enabled"

	enabled = anObject ifTrue: [^self].
	enabled := anObject.
	self changed: #enabled.
	self
		adoptPaneColor: self paneColor;
		changed