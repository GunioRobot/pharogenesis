updateHeadlight

	| headLight camera |
	camera := scene defaultCamera.
	(self scene lights isKindOf: Dictionary)
		ifTrue: [headLight := self scene lights at: '$HeadLight$' ifAbsent: []]
		ifFalse: [headLight := nil].
	headLight ifNotNil: [
		headLight
			position: camera position;
			target: camera target].
