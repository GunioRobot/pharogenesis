selectedSuite: anInteger
	anInteger > 0 ifTrue: [ | selected |
		selected _ selectedSuite ~= anInteger.
		selectedSuites at: anInteger put: selected.
	] ifFalse: [
		"selectedSuite > 0 ifTrue: [ selectedSuites at: selectedSuite put: false ]."
	].
	selectedSuite _ anInteger.
	selectedFailureTest _ 0.
	selectedErrorTest _ 0.
	self changed: #selectedFailureTest.             "added rew"
	self changed: #selectedErrorTest.               "added rew" 
	self changed: #selectedSuite.
	self changed: #allSelections.
