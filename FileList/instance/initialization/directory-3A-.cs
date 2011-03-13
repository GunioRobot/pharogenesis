directory: dir
	"Set the path of the volume to be displayed."
	sortMode == nil ifTrue: [sortMode _ #name].
	self okToChange ifFalse: [^ self].
	directory _ dir.
	volList _ (Array with: 'Desk Top') , directory pathParts.
	self changed: #relabel.
	self changed: #list.
	self newListAndPattern: (pattern == nil ifTrue: ['*']
										ifFalse: [pattern]).
