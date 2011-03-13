updateWorldMainDockingBar
	| oldPreference |
	oldPreference := Project current showWorldMainDockingBar.
	""
	Project current showWorldMainDockingBar: false.
	Project current showWorldMainDockingBar: oldPreference.
	TheWorldMainDockingBar updateInstances