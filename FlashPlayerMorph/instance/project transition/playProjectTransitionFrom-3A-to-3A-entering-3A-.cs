playProjectTransitionFrom: oldProject to: newProject entering: aBoolean
	"Play the transition from the old to the new project."

	Smalltalk isMorphic ifFalse: [^ self]. "Not in MVC"
	self stopPlaying.
	owner ifNotNil:[
		self stopStepping.
		owner removeMorph: self].
	aBoolean ifTrue:[
		self updateProjectFillsFrom: newProject.
	] ifFalse:[
		self updateProjectFillsFrom: oldProject.
		self setProperty: #transitionBackground toValue: newProject imageForm.
	].
	self frameNumber: 1.
	self loopFrames: false.
	(self valueOfProperty: #fullScreenTransition ifAbsent:[false])
		ifTrue:[self bounds: self world bounds].
	self comeToFront.
	self startStepping.
	self startPlaying.
	[playing] whileTrue: [World doOneCycleNow].
	self stopPlaying.
	self stopStepping.
	owner removeMorph: self.
	self removeProperty: #transitionBackground.
	Display deferUpdates: true.
	ActiveWorld fullDrawOn: (Display getCanvas).
	Display deferUpdates: false.