enter: returningFlag revert: revertFlag saveForRevert: saveForRevert
	"Install my ChangeSet, Transcript, and scheduled views as current globals. If returningFlag is true, we will return to the project from whence the current project was entered; don't change its previousProject link in this case.
	If saveForRevert is true, save the ImageSegment of the project being left.
	If revertFlag is true, make stubs for the world of the project being left.
	If revertWithoutAsking is true in the project being left, then always revert."

	| showZoom recorderOrNil old forceRevert response seg |
	self == CurrentProject ifTrue: [^ self].
	"Check the guards"
	guards ifNotNil:
		[guards _ guards reject: [:obj | obj isNil].
		guards do: [:obj | obj okayToEnterProject ifFalse: [^ self]]].
	forceRevert _ false.
	CurrentProject rawParameters 
		ifNil: [revertFlag ifTrue: [^ self inform: 'nothing to revert to']]
		ifNotNil: [saveForRevert ifFalse: [
				forceRevert _ CurrentProject projectParameters 
								at: #revertWithoutAsking ifAbsent: [false]]].
	forceRevert not & revertFlag ifTrue: [
		response _ SelectionMenu confirm: 'Are you sure you want to destroy this Project\ and revert to an older version?\\(From the parent project, click on this project''s thumbnail.)' withCRs
			trueChoice: 'Revert to saved version' 
			falseChoice: 'Cancel'.
		response ifFalse: [^ self]].

	revertFlag | forceRevert 
		ifTrue: [seg _ CurrentProject projectParameters at: #revertToMe ifAbsent: [
					^ self inform: 'nothing to revert to']]
		ifFalse: [CurrentProject makeThumbnail].
	(revertFlag | saveForRevert | forceRevert) ifFalse: [
		(Preferences valueOfFlag: #projectsSentToDisk) ifTrue: [
			self storeToMakeRoom]].

	Smalltalk isMorphic ifTrue: [World triggerClosingScripts].

	"Update the display depth and make a thumbnail of the current project"
	CurrentProject displayDepth: Display depth.
	old _ CurrentProject.		"for later"

	"Show the project transition.
	Note: The project zoom is run in the context of the old project,
		so that eventual errors can be handled accordingly"
	displayDepth == nil ifTrue: [displayDepth _ Display depth].
	self installNewDisplay: Display extent depth: displayDepth.

	(showZoom _ self showZoom) ifTrue: [
		self displayZoom: CurrentProject parent ~~ self].

	(world isMorph and: [world hasProperty: #letTheMusicPlay])
		ifTrue: [world removeProperty: #letTheMusicPlay]
		ifFalse: [Smalltalk at: #ScorePlayer ifPresent: [:playerClass | 
					playerClass allSubInstancesDo: [:player | player pause]]].

	returningFlag
		ifTrue: [nextProject _ CurrentProject]
		ifFalse: [previousProject _ CurrentProject].

	CurrentProject saveState.
	CurrentProject isolationHead == self isolationHead ifFalse:
		[self invokeFrom: CurrentProject].
	CurrentProject _ self.
	Smalltalk newChanges: changeSet.
	TranscriptStream newTranscript: transcript.
	Sensor flushKeyboard.
	Smalltalk isMorphic ifTrue: [recorderOrNil _ World pauseEventRecorder].

	world isMorph
		ifTrue:
			[World _ world.  "Signifies Morphic"
			world install.
			"(revertFlag | saveForRevert | forceRevert) ifFalse: [
				(Preferences valueOfFlag: #projectsSentToDisk) ifTrue: [
					self storeSomeSegment]]."
			recorderOrNil ifNotNil: [recorderOrNil resumeIn: World].
			world triggerOpeningScripts]
		ifFalse:
			[World _ nil.  "Signifies MVC"
			Smalltalk at: #ScheduledControllers put: world].

	saveForRevert ifTrue: [
		Smalltalk garbageCollect.	"let go of pointers"
		old storeSegment.
		"result _" old world isInMemory 
			ifTrue: ['Can''t seem to write the project.']
			ifFalse: [old projectParameters at: #revertToMe put: 
					old world xxxSegment clone].
				'Project written.'].
			"original is for coming back in and continuing."

	revertFlag | forceRevert ifTrue: [
		seg clone revert].	"non-cloned one is for reverting again later"
	self removeParameter: #exportState.

	"Complete the enter: by launching a new process"
	world isMorph
		ifTrue:
			[self spawnNewProcessAndTerminateOld: true]
		ifFalse:
			[showZoom ifFalse: [ScheduledControllers restore].
			ScheduledControllers searchForActiveController]