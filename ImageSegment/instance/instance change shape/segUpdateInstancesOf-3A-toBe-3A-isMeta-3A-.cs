segUpdateInstancesOf: oldClass toBe: newClass isMeta: isMeta
	| withSymbols oldInstances segSize |
	"Bring me in, locate instances of oldClass and get them converted.  Write me out again."

	(state = #onFile or: [state = #onFileWithSymbols]) ifFalse: [^ self].
	withSymbols _ state = #onFileWithSymbols.
	"If has instances, they point out at the class"
	(outPointers includes: oldClass) ifFalse: [
		oldClass == SmallInteger ifTrue: [^ self].	"instance not changable"
		oldClass == Symbol ifTrue: [^ self].	"instance is never in a segment"
		oldClass == ByteSymbol ifTrue: [^ self].	"instance is never in a segment"
		(Smalltalk compactClassesArray includes: oldClass) ifFalse: [^ self]].
		"For a compact class, must search the segment.  Instance does not 
		 point outward to class"
	state = #onFile ifTrue: [Cursor read showWhile: [self readFromFile]].
	segSize _ segment size.
	self install.
	oldInstances _ OrderedCollection new.
	self allObjectsDo: [:obj | obj class == oldClass ifTrue: [
		oldInstances add: obj]].
	newClass updateInstances: oldInstances asArray from: oldClass isMeta: isMeta.
	self copyFromRoots: arrayOfRoots sizeHint: segSize.
	self extract.
	withSymbols 
		ifTrue: [self writeToFileWithSymbols]
		ifFalse: [self writeToFile].
