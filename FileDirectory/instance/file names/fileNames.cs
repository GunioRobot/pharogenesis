fileNames
	"FileDirectory default fileNames"
	^ self directoryContents collect: [:spec | spec first]