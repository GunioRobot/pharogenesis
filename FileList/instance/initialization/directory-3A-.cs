directory: dir
	"Set the path of the volume to be displayed."
	sortMode == nil ifTrue: [sortMode _ #date].   "2/7/97 sw personal preference"
	self okToChange ifFalse: [^ self].
	directory _ dir.
	volList _ (Array with: '[]'), directory pathParts.
	self changed: #relabel.
	self changed: #list.
	self newListAndPattern: (pattern == nil ifTrue: ['*']
										ifFalse: [pattern]).
