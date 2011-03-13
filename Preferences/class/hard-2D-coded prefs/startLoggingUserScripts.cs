startLoggingUserScripts
	"Execute this to set the system to start logging user scripts to the changes log.  7/18/96 sw"
	"Preferences startLoggingUserScripts"

	Preferences class compile:
'logUserScripts
	"Set to true if you want user scripts logged; later, we will maybe have a better way to specify this, or do something better altogether"

	^ true' classified: 'logging'