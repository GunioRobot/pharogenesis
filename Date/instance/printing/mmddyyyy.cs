mmddyyyy
	"Answer the receiver rendered in standard fmt mm/dd/yyyy.  Good for avoiding year 2000 bugs.  Note that the name here is slightly misleading -- the month and day numbers don't show leading zeros, so that for example feb 1 1996 is 2/1/96"

	"Date today mmddyyyy"

	^ self printFormat: #(2 1 3 $/ 1 1)