project: aProject actionBlock: aBlock

	theProject _ aProject.
	actionBlock _ aBlock.
	(namedFields at: 'projectname') contentsWrapped: theProject name.