deselectAll
	selectedSuites _ tests collect: [ :ea | false ].
	selectedSuite _ 0.
      self changed: #allSelections.
 