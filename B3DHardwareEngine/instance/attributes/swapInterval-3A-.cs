swapInterval: interval
	"Set the swap interval for the receiver (only in HW implementations).
	The swap interval is defined as:
		0	-	don't wait for vertical blank.
		1	-	swap only on vertical blank.
		n	-	swap only every n vertical blanks."
	self primRender: handle setProperty: -1 toInteger: interval.