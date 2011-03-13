installMember: member
	 | str |
	self useNewChangeSetDuring:
		[str := member contentStream text.
		str setConverterForCode.
		str fileInAnnouncing: 'loading ', member fileName]