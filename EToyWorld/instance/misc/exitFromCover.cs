exitFromCover

	(self confirm: 'Do really want to exit?') ifFalse: [^ self].

	self presenter ifNotNil: [presenter stopRunningScripts].
	Cursor normal show.
	(Preferences valueOfFlag: #quitWhenExitingImagineeringStudio)
		ifTrue: [Smalltalk snapshot: false andQuit: true].
	self standardSystemController closeAndUnschedule.
