wantsRoundedCorners
	"Answer whether rounded corners are wanted."
	
	^(self theme windowPreferredCornerStyleFor: self) == #rounded