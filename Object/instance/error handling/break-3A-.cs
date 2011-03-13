break: aMessage 
	"Call break: instead of self halt, you can browse all your breakpoints by browsing senders of #break:  The halt is bypassed if the shift key is down.  1/18/96 sw"

	Sensor leftShiftDown ifFalse:
		[self halt: aMessage]