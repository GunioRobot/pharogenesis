changesName  "Smalltalk changesName"
	"Answer the current name for the changes file that matches the image file name"
	| imName index |
	FileDirectory splitName: self imageName
		to: [:volName :fileName | imName _ fileName].
	imName size > 5 ifTrue: 
		[(index _ (imName findString: '.image' startingAt: imName size - 5)) > 0 ifTrue: 
			[^(imName copyFrom: 1 to: index-1), '.changes']].
	^imName, '.changes'
