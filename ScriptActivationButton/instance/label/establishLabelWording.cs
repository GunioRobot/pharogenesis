establishLabelWording
	"Set the label wording, unless it has already been manually edited"

	| itsName |
	itsName _ target externalName.
	(self hasProperty: #labelManuallyEdited)
		ifFalse:
			[self label: (itsName, ' ', arguments first)].
	self setBalloonText: 'click to run the script "', arguments first, '" in player named "', itsName, '"'