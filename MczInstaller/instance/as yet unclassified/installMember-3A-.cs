installMember: member
	 | str |
	self useNewChangeSetDuring:
		[str _ member contentStream text.
		str setConverterForCode.
		str fileInAnnouncing: 'loading ', member fileName]