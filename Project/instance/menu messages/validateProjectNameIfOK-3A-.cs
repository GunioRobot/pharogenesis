validateProjectNameIfOK: aBlock

	| details |

	details _ world valueOfProperty: #ProjectDetails.
	details ifNotNil: ["ensure project info matches real project name"
		details at: 'projectname' put: self name.
	].
	self doWeWantToRename ifFalse: [^aBlock value].
	EToyProjectDetailsMorph
		getFullInfoFor: self 
		ifValid: [
			World displayWorldSafely.
			aBlock value.
		] fixTemps
		expandedFormat: false
