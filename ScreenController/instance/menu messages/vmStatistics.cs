vmStatistics
	"Open a string view on a report of vm statistics"

	StringHolderView
		open: (StringHolder new contents: Utilities vmStatisticsReportString)
		label: 'VM Statistics'