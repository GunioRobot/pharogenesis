toggleSelections
	selectedSuites _ selectedSuites collect: [ :ea | ea not ].
	selectedSuite _ selectedSuites indexOf: true ifAbsent: [0].
	self changed: #allSelections .
