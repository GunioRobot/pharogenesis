project: aProject actionBlock: aBlock

	theProject _ aProject.
	actionBlock _ aBlock.
	projectDetails _ theProject world valueOfProperty: #ProjectDetails ifAbsent: [Dictionary new]