color: aFillStyle
	color _ aFillStyle.
	self tabs do: [ :anAssociation |
		anAssociation key color: aFillStyle ]
