vmStatisticsShortString
	"Convenience item for access to recent statistics only"
	"StringHolderView open: (StringHolder new contents: Utilities vmStatisticsShortString)
		label: 'VM Recent Statistics'"

	^ (ReadStream on: self vmStatisticsReportString) upToAll: 'Since'; upTo: Character cr; upToEnd
