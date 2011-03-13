queryForNewEntry

	| array entry |
	array _ Array new: theList size.
	1 to: array size do: [:column |
		entry _ self queryColumnEntry: column default: column printString.
		entry isEmpty ifTrue: [^nil].
		array at: column put: entry].
	^array
