validate: aProject andDo: aBlock

	(self new)
		project: aProject actionBlock: aBlock;
		openCenteredInWorld