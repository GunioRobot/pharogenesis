unlockOneSubpart
	| unlockables aMenu reply |
	unlockables _ self submorphs select:
		[:m | m isLocked].
	unlockables size <= 1 ifTrue: [^ self unlockContents].
	aMenu _ SelectionMenu labelList: (unlockables collect: [:m | m externalName]) selections: unlockables.
	reply _ aMenu startUpWithCaption: 'Who should be be unlocked?' translated.
	reply isNil ifTrue: [^ self].
	reply unlock