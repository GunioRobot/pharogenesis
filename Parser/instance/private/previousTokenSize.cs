previousTokenSize
	"Answer the size of the previous token. Bugfix for Strings."

	| hereSize |
	hereType == #number ifTrue: [^ mark - prevMark].
	hereSize _ here ifNil: [0] ifNotNil: [here size].
	hereType == #string ifTrue: [^ hereSize + 2].   "One for each single quote"
	^ hereSize