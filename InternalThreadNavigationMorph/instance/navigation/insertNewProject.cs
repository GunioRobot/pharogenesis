insertNewProject

	| newProj |

	[newProj _ Project newMorphicOn: nil.]
		on: ProjectViewOpenNotification
		do: [ :ex | ex resume: false].	

	EToyProjectDetailsMorph 
		getFullInfoFor: newProj
		ifValid: [self insertNewProjectActionFor: newProj]
		expandedFormat: false.


