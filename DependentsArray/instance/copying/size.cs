size
	
	"No nil verification required. See do: implementation that only evaluates not nil objects"
	^self inject: 0 into: [:size :anObject | size + 1]