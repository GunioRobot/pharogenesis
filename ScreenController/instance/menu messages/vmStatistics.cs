vmStatistics
	"Open a string view on a report of vm statistics"

	(StringHolder new contents: SmalltalkImage current  vmStatisticsReportString)
		openLabel: 'VM Statistics'