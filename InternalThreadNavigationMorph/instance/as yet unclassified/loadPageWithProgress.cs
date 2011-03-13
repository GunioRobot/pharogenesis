loadPageWithProgress

	| projectInfo projectName |

	projectInfo _ listOfPages at: currentIndex.
	projectName _ projectInfo at: 1.
	loadedProject _ Project named: projectName.
	self class know: listOfPages as: threadName.
	WorldState addDeferredUIMessage: [
		InternalThreadNavigationMorph openThreadNamed: threadName
	].

	loadedProject ifNil: [
		ComplexProgressIndicator new 
			targetMorph: self;
			historyCategory: 'project loading';
			withProgressDo: [
				[
					loadedProject _ CurrentProjectRefactoring 
							currentFromMyServerLoad: projectName
				] 
					on: ProjectViewOpenNotification
					do: [ :ex | ex resume: false]		
						"we probably don't want a project view morph in this case"
			].
	].
	loadedProject ifNil: [
		^self inform: 'I cannot find that project'
	].
	self delete.

	loadedProject enter.
