enter: returningFlag
	"Install my ChangeSet, Transcript, and scheduled views as current globals. If returningFlag is true, we are return to the project from whence the current project was entered; don't change its previousProject link in this case."

	| newDisplay entering vanishingPoint showZoom |
	self == CurrentProject ifTrue: [^ self].
	returningFlag ifFalse: [
		"record link to previous project unless we're returning via that link"
		previousProject _ CurrentProject].

	"Same code runs for enter and exit; test which for zoom"
	entering _ self ~~ CurrentProject parent.
	displayDepth == nil ifTrue: [displayDepth _ Display depth].
	CurrentProject makeThumbnail.
	CurrentProject saveState.
	CurrentProject _ self.
	Smalltalk newChanges: changeSet.
	TranscriptStream newTranscript: transcript.
	showZoom _ Preferences showProjectZoom
		and: [Smalltalk garbageCollectMost > (Display boundingBox area*displayDepth//8+200000)].
	Display replacedBy:
			(showZoom
				ifTrue: [newDisplay _ DisplayScreen extent: Display extent
													depth: displayDepth]
				ifFalse: [Display newDepthNoRestore: displayDepth])
		do: [world isMorph
				ifTrue: [World _ world.  "Signifies Morphic"
						world install]
				ifFalse: [World _ nil.  "Signifies MVC"
						Smalltalk at: #ScheduledControllers put: world.
						ScheduledControllers restore]].
	showZoom
		ifTrue: ["Show animated zoom to new display"
				vanishingPoint _ Sensor cursorPoint.
				(entering ifTrue: [self] ifFalse: [previousProject]) dependents do:
					[:v | (v isKindOf: StandardSystemView)
						ifTrue: [vanishingPoint _ v windowBox center]].
				Display zoomIn: entering orOutTo: newDisplay at: 0@0
							vanishingPoint: vanishingPoint.
				displayDepth ~= Display depth ifTrue:
					[Display newDepthNoRestore: displayDepth.
					newDisplay displayOn: Display at: 0@0]].
	world isMorph
		ifTrue: [self spawnNewProcess]
		ifFalse: [world searchForActiveController]