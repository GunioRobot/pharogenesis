dateStampNow
	"Return the current date and time formatted as a email Date: line"
	"The result conforms to RFC822 with a long year, e.g.  'Thu, 18 Feb 1999 20:38:51'"

	^	(Date today weekday copyFrom: 1 to: 3), ', ',
		(Date today printFormat: #(1 2 3 $  2 1 1)), ' ',
		Time now print24