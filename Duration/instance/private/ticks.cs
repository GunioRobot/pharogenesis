ticks
	"Answer an array {days. seconds. nanoSeconds}. Used by DateAndTime and Time"

	^ Array 
		with: self days
		with: (self hours * 3600) + (self minutes * 60 ) + (self seconds truncated)
		with: self nanoSeconds