findAFileList: evt 
	"Locate a file list, open it, and bring it to the front.
	Create one if necessary, respecting the Preference."

	self
		findAWindowSatisfying: [:aWindow | aWindow model isKindOf: FileList]
		orMakeOneUsing: [FileList2 prototypicalToolWindow]
