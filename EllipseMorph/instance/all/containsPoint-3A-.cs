containsPoint: aPoint

	| radius other delta xOverY |
	(bounds containsPoint: aPoint) ifFalse: [^ false].  "quick elimination"
	(bounds width = 1 or: [bounds height = 1])
		ifTrue: [^ true].  "Degenerate case -- code below fails by a bit"

	radius _ bounds height asFloat / 2.
	other _ bounds width asFloat / 2.
	delta _ aPoint - bounds topLeft - (other@radius).
	xOverY _ bounds width asFloat / bounds height asFloat.
	^ (delta x asFloat / xOverY) squared + delta y squared <= radius squared