erase
	"Clear the display box of the receiver to be gray, as the screen background."
	| oldValid |
	CacheBits
		ifTrue:
			[oldValid := bitsValid.
			bitsValid := false.
			ScheduledControllers restore: self windowBox without: self.
			bitsValid := oldValid]
		ifFalse:
			[ScheduledControllers restore: self windowBox without: self]