findAFileList: evt 
	"Locate a file list, open it, and bring it to the front.
	Create one if necessary, respecting the Preference."

	self
		findAWindowSatisfying: [:aWindow | aWindow model isKindOf: FileList]
		orMakeOneUsing: [Preferences useFileList2
				ifTrue: [FileList2 prototypicalToolWindow]
				ifFalse: [FileList prototypicalToolWindow]]