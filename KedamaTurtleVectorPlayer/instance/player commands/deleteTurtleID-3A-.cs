deleteTurtleID: who

	| whoArray whoIndex newArray |
	whoArray _ arrays at: 1.
	whoIndex _ whoArray indexOf: who ifAbsent: [^ self].
	deletingIndex _ whoIndex - 1.
	arrays withIndexDo: [:array :index |
		newArray _ (array copyFrom: 1 to: whoIndex - 1), (array copyFrom: whoIndex + 1 to: array size).
		arrays at: index put: newArray.
	].
	whoTableValid _ false.
	turtleMapValid _ false.
