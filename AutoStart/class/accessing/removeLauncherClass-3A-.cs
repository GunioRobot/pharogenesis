removeLauncherClass: launcherClass
"	| launchersToBeRemoved |
	launchersToBeRemoved _ self installedLaunchers select: [:launcher |
		launcher class == launcherClass].
	launchersToBeRemoved do: [:launcher | self removeLauncher: launcher]"
	self removeLauncher: launcherClass