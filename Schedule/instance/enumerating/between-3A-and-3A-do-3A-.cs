between: aStart and: anEnd do: aBlock

	| element end i |
	end _ self end min: anEnd.
	element _ self start.
	
	i _ 1.
	[ element < aStart ] whileTrue:
	
	[ element _ element + (schedule at: i).
		i _ i + 1. (i > schedule size) ifTrue: [i _ 1]].
	i _ 1.
	[ element <= end ] whileTrue:
	
	[ aBlock value: element.
		element _ element + (schedule at: i).
		i _ i + 1.
		(i > schedule size) ifTrue: [i _ 1]]
.
