directory: dir
	"Set the path of the volume to be displayed."

	self okToChange ifFalse: [^ self].

	self modelSleep.
	directory _ dir.
	self modelWakeUp.

	sortMode == nil ifTrue: [sortMode _ #date].
	volList _ Array with: '[]'.
	directory ifNotNil: [
		volList _ volList, directory pathParts.  "Nesting suggestion from RvL"
	].
	volList _ volList withIndexCollect: [:each :i | ( String new: i-1 withAll: $ ), each].
	self changed: #relabel.
	self changed: #volumeList.
	self pattern: pattern.
	directoryChangeBlock ifNotNil: [directoryChangeBlock value: directory].