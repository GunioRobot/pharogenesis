chooseAndRevertToVersion
	| time which |
	"Let the user choose an older version for all code in MethodMorphs in this book.  Run through that code and revert each one to that time."

	self methodHolders.	"find them in me"
	self methodHolderVersions.
	which _ PopUpMenu withCaption: 
					'Put all scripts in this book back 
the way they were at this time:' 
				chooseFrom: #('leave as is'), VersionNames.
	which <= 1 ifTrue: [^ self].
	time _ VersionTimes at: which-1.
	self revertToCheckpoint: time.