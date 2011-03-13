erase
	"Clear the display box of the receiver to be gray, as the screen background."
	| oldValid |
	CacheBits
		ifTrue:
			[oldValid _ bitsValid.
			bitsValid _ false.
			ScheduledControllers restore: self windowBox without: self.
			bitsValid _ oldValid.]
		ifFalse:
			[self clear: Color gray.
			Display fillGray: self windowBox]