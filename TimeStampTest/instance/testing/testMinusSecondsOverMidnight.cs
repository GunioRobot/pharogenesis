testMinusSecondsOverMidnight
	self assert: (aTimeStamp minusSeconds: 34 * 60 + 57) dateAndTime
			= (Array with: '01-01-2004' asDate with: '23:59:59' asTime)
	"Bug The results are actual results are: #(1 January 2005 11:25:03 pm)"