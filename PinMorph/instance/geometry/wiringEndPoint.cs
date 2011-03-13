wiringEndPoint
	| side |
	side _ owner bounds sideNearestTo: bounds center.
	side = #left ifTrue: [^ self position + (0@4)].
	side = #bottom ifTrue: [^ self position + (4@7)].
	side = #right ifTrue: [^ self position + (7@4)].
	side = #top ifTrue: [^ self position + (4@0)]