changeViewAllContents

	(viewAllContents not and: [ self selectedMember notNil and: [ self selectedMember uncompressedSize > 50000 ]])
		ifTrue: [ (PopUpMenu confirm: 'This member''s size is ',
			(self selectedMember uncompressedSize asString),
			'; do you really want to see all that data?')
				ifFalse: [ ^self ]
		].

	viewAllContents _ viewAllContents not.
	self changed: #contents