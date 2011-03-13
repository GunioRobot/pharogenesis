storeOldRequirementsUnder: rc into: oldRequiredSelectorsByClass ignoreSet: classWithOldRequirementsRecorded 
	classesToUpdate do: 
			[:someClass | 
			(rc == someClass or: [(someClass inheritsFrom: rc)])
				ifTrue: 
					[(classWithOldRequirementsRecorded includes: someClass) 
						ifFalse: 
							[oldRequiredSelectorsByClass at: someClass put: someClass requirements]]]