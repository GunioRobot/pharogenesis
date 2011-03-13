directory: dir
	"Set the path of the volume to be displayed."

	sortMode == nil ifTrue: [sortMode _ #date].
	self okToChange ifFalse: [^ self].
	directory _ dir.
	volList _ ((Array with: '[]'), directory pathParts)  "Nesting suggestion from RvL"
			withIndexCollect: [:each :i | ( String new: i-1 withAll: $ ), each].
	self changed: #relabel.
	self changed: #volumeList.
	self pattern: pattern.
	self changed: #contents.