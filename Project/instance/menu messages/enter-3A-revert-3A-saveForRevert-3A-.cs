enter: returningFlag revert: revertFlag saveForRevert: saveForRevert 
	"Install my ChangeSet, Transcript, and scheduled views as current
	globals. If returningFlag is true, we will return to the project from
	whence the current project was entered; don't change its
	previousProject link in this case.
	If saveForRevert is true, save the ImageSegment of the project being
	left. If revertFlag is true, make stubs for the world of the project being
	left. If revertWithoutAsking is true in the project being left, then
	always revert."
	| recorderOrNil old forceRevert response seg |
	(world isKindOf: StringMorph)
		ifTrue: [self inform: 'This project is not all here. I will try to load a complete version.' translated.
			^ true].
	self isCurrentProject
		ifTrue: [^ self].
	CurrentProject world triggerEvent: #aboutToLeaveWorld.
	forceRevert := false.
	CurrentProject rawParameters
		ifNil: [revertFlag
				ifTrue: [^ self inform: 'nothing to revert to' translated]]
		ifNotNil: [saveForRevert
				ifFalse: [forceRevert := CurrentProject projectParameters
								at: #revertWithoutAsking
								ifAbsent: [false]]].
	forceRevert not & revertFlag
		ifTrue: [response := self
						confirm: 'Are you sure you want to destroy this Project\ and revert to an older version?\\(From the parent project, click on this project''s thumbnail.)' translated withCRs.
			response
				ifFalse: [^ self]].
	revertFlag | forceRevert
		ifTrue: [seg := CurrentProject projectParameters
						at: #revertToMe
						ifAbsent: [^ self inform: 'nothing to revert to' translated]]
		ifFalse: [
			CurrentProject makeThumbnail.
			returningFlag == #specialReturn
				ifTrue: [
					"this guy is irrelevant"
					Project forget: CurrentProject]
				ifFalse: []].
	revertFlag | saveForRevert | forceRevert
		ifFalse: [(Preferences valueOfFlag: #projectsSentToDisk)
				ifTrue: [self storeToMakeRoom]].
	CurrentProject abortResourceLoading.
	CurrentProject saveProjectPreferences.
	"Update the display depth and make a thumbnail of the current project"
	CurrentProject displayDepth: Display depth.
	old := CurrentProject.
	"for later"
	"Show the project transition.
	Note: The project zoom is run in the context of the old project,
	so that eventual errors can be handled accordingly"
	displayDepth == nil
		ifTrue: [displayDepth := Display depth].
	self installNewDisplay: Display extent depth: displayDepth.
	(self showZoom)
		ifTrue: [self displayZoom: CurrentProject parent ~~ self].
	(world isMorph
			and: [world hasProperty: #letTheMusicPlay])
		ifTrue: [world removeProperty: #letTheMusicPlay]
		ifFalse: [Smalltalk
				at: #ScorePlayer
				ifPresentAndInMemory: [:playerClass | playerClass
						allSubInstancesDo: [:player | player pause]]].
	returningFlag == #specialReturn
		ifTrue: [old removeChangeSetIfPossible.
			"keep this stuff from accumulating"
			nextProject := nil]
		ifFalse: [returningFlag
				ifTrue: [nextProject := CurrentProject]
				ifFalse: [previousProject := CurrentProject]].
	CurrentProject saveState.
	CurrentProject isolationHead == self isolationHead
		ifFalse: [self invokeFrom: CurrentProject].
	CurrentProject := self.
	self installProjectPreferences.
	ChangeSet newChanges: changeSet.
	TranscriptStream newTranscript: transcript.
	Sensor flushKeyboard.
	recorderOrNil := World pauseEventRecorder.
	World := world.
	"Signifies Morphic"
	world install.
	 
	"(revertFlag | saveForRevert | forceRevert) ifFalse: [
	(Preferences valueOfFlag: #projectsSentToDisk) ifTrue: [
	self storeSomeSegment]]."
	recorderOrNil
		ifNotNil: [recorderOrNil resumeIn: world].

	saveForRevert
		ifTrue: [Smalltalk garbageCollect.
			"let go of pointers"
			old storeSegment.
			"result :="
			old world isInMemory
				ifTrue: ['Can''t seem to write the project.']
				ifFalse: [old projectParameters at: #revertToMe put: old world xxxSegment clone].
			'Project written.'].
	"original is for coming back in and continuing."
	revertFlag | forceRevert
		ifTrue: [seg clone revert].
	"non-cloned one is for reverting again later"
	self removeParameter: #exportState.
	"Complete the enter: by launching a new process"
	world triggerEvent: #aboutToEnterWorld.
	Project spawnNewProcessAndTerminateOld: true