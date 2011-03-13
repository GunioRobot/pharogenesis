outOfDate: aServer
	"Inform the user that this server does not have a current version of 'Updates.list'  Return true if the user does not want any updates to happen."

| response |
response _ (PopUpMenu labels: 'Install on others\Cancel entire update' withCRs)
		startUpWithCaption: 'The server ', aServer moniker, ' is not up to date.
Please store the missing updates maually.'.
^ response ~= 1