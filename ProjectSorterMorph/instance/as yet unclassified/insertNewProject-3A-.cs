insertNewProject: evt

	| newProj |

	[newProj _ Project newMorphicOn: nil.]
		on: ProjectViewOpenNotification
		do: [ :ex | ex resume: false].	

	EToyProjectDetailsMorph 
		getFullInfoFor: newProj
		ifValid: [
			evt hand attachMorph: (self sorterMorphForProjectNamed: newProj name)
		]
		expandedFormat: false.


