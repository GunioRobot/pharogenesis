drawOn: aCanvas
	self tabs size > 0 ifFalse: [^ self ].
	self tabs do: [ :anAssociation | | tab |
		tab _ anAssociation key.
		tab drawOn: aCanvas]