establishLabelWording
	| itsName |
	self label: ((itsName _ target externalName), ' ', arguments first).
	self setBalloonText: 'click to run the script "', arguments first, '" in player named "', itsName, '"'