computeFill
	(destForm isNil or:[destForm width < self width]) ifTrue:[
		destForm _ Form extent: (self width + 10) @ 1 depth: 32.
	].
	source computeFillFrom: minX to: maxX at: yValue in: destForm