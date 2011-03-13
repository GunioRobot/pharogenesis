mmddyy
	"Please use mmddyyyy instead, so dates in 2000 will be unambiguous"
	"Answer the receiver rendered in standard fmt mm/dd/yy. 1/17/96 sw.  2/1/96 sw Fixed to show day of month, not day.  Note that the name here is slightly misleading -- the month and day numbers don't show leading zeros, so that for example feb 1 1996 is 2/1/96"

	"Date today mmddyy"

	^ self printFormat: #(2 1 3 $/ 1 2)