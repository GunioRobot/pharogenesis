serviceConflictsWithUpdatedMethods
	^ SimpleServiceEntry 
		provider: self 
		label: 'conflicts with updated methods'
		selector: #conflictsWithUpdatedMethods:
		description: 'check for conflicts with more recently updated methods in the image, showing the conflicts in a transcript window'
		buttonLabel: 'conflicts'