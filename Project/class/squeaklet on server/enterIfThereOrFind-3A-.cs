enterIfThereOrFind: aProjectName

	| newProject |
	newProject _ Project named: aProjectName.
	newProject ifNotNil: [^newProject enter].

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			[
				newProject _ CurrentProject fromMyServerLoad: aProjectName
			] 
				on: ProjectViewOpenNotification
				do: [ :ex | ex resume: false]		
					"we probably don't want a project view morph in this case"
		].

	newProject ifNotNil: [^newProject enter].
	Beeper beep.