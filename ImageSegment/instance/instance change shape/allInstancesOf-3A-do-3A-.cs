allInstancesOf: aClass do: aBlock
	| withSymbols oldInstances segSize |
	"Bring me in, locate instances of aClass and submit them to the block.  Write me out again."

	(state = #onFile or: [state = #onFileWithSymbols]) ifFalse: [^ self].
	withSymbols _ state = #onFileWithSymbols.
	(outPointers includes: aClass) ifFalse: [^ self].
		"If has instances, they point out at the class"
	state = #onFile ifTrue: [Cursor read showWhile: [self readFromFile]].
	segSize _ segment size.
	self install.
	oldInstances _ OrderedCollection new.
	self allObjectsDo: [:obj | obj class == aClass ifTrue: [
		oldInstances add: obj]].
	oldInstances do: [:inst | aBlock value: inst].	"do the work"
	self copyFromRoots: arrayOfRoots sizeHint: segSize.
	self extract.
	withSymbols 
		ifTrue: [self writeToFileWithSymbols]
		ifFalse: [self writeToFile].

