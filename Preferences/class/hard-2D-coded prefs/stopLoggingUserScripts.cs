stopLoggingUserScripts
	"Execute this to set the system to stop logging user scripts to the changes log.  7/18/96 sw"
	"Preferences stopLoggingUserScripts"

	Preferences class compile:
'logUserScripts
	"Set to true if you want user scripts logged; later, we will maybe have a better way to specify this, or do something better altogether"

	^ false' classified: 'logging'