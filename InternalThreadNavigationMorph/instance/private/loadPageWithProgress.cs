loadPageWithProgress
	"Load the desired page, showing a progress indicator as we go"
	
	| projectInfo projectName beSpaceHandler |
	projectInfo _ listOfPages at: currentIndex.
	projectName _ projectInfo first.
	loadedProject _ Project named: projectName.
	self class know: listOfPages as: threadName.
	beSpaceHandler _ (ActiveWorld keyboardNavigationHandler == self).
	WorldState addDeferredUIMessage:
		[InternalThreadNavigationMorph openThreadNamed: threadName atIndex: currentIndex beKeyboardHandler: beSpaceHandler] fixTemps.

	loadedProject ifNil: [
		ComplexProgressIndicator new 
			targetMorph: self;
			historyCategory: 'project loading' translated;
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
		^self inform: 'I cannot find that project' translated
	].
	self delete.

	loadedProject enter.
