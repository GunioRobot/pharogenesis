installRepository: aString for: packageName

	(MCWorkingCopy allManagers select: [:each | each package name = packageName])
		first repositoryGroup
		addRepository: (MCHttpRepository new location: aString ; user: '' ; password: '')
		