directory: dir
	"Set the path of the volume to be displayed."

	self okToChange ifFalse: [^ self].

	self modelSleep.
	directory _ dir.
	self modelWakeUp.

	sortMode == nil ifTrue: [sortMode _ #date].
	volList _ ((Array with: '[]'), directory pathParts)  "Nesting suggestion from RvL"
			withIndexCollect: [:each :i | ( String new: i-1 withAll: $ ), each].
	volListIndex := volList size.
	self changed: #relabel.
	self changed: #volumeList.
	self pattern: pattern