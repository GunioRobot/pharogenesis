vmStatisticsReportString
	"StringHolderView open: (StringHolder new contents:
		Utilities vmStatisticsReportString) label: 'VM Statistics'"

	self deprecated: 'Use SmalltalkImage current  vmStatisticsReportString'.

	^SmalltalkImage current vmStatisticsReportString