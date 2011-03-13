updateHeadlight

	| headLight camera |
	camera := scene defaultCamera.
	(self scene lights isKindOf: Dictionary)
		ifTrue: [headLight := self scene lights at: '$HeadLight$' ifAbsent: []]
		ifFalse: [headLight := nil].
	headLight
		ifNil: [
			((headLightStatus = #on) and: [self scene lights isKindOf: Dictionary]) ifTrue: [
				self scene lights at: '$HeadLight$' put: savedHeadLight.
				headLight := savedHeadLight]]
		ifNotNil: [
			(headLightStatus = #off) ifTrue: [
				savedHeadLight := headLight.
				self scene lights removeKey: '$HeadLight$']].
	headLight ifNotNil: [
		headLight
			position: camera position;
			target: camera target].
