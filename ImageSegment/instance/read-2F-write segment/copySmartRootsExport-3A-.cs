copySmartRootsExport: rootArray 
	"Use SmartRefStream to find the object.  Make them all roots.  Create the segment in memory.  Project should be in first five objects in rootArray."
	| newRoots list segSize symbolHolder dummy replacements world naughtyBlocks goodToGo allClasses |
	Smalltalk forgetDoIts.  
	1 to: 5 do: [:ii | ((rootArray at: ii) respondsTo: #isCurrentProject) ifTrue: [
					world _ rootArray at: ii]].
	world ifNotNil: [world presenter flushPlayerListCache].	"old and outside guys"
	symbolHolder _ Symbol allInstances.	"Hold onto Symbols with strong pointers, 
		so they will be in outPointers"

	dummy _ ReferenceStream on: (DummyStream on: nil).
		"Write to a fake Stream, not a file"
	"Collect all objects"
	dummy insideASegment: true.	"So Uniclasses will be traced"
	dummy rootObject: rootArray.	"inform him about the root"
	dummy nextPut: rootArray.
	allClasses _ SmartRefStream new uniClassInstVarsRefs: dummy.
		"catalog the extra objects in UniClass inst vars.  Put into dummy"
	allClasses do: [:cls | 
		dummy references at: cls class put: false.	"put Player5 class in roots"
		dummy blockers removeKey: cls class ifAbsent: []].
	"refs _ dummy references."
	arrayOfRoots _ self smartFillRoots: dummy.	"guaranteed none repeat"
	self savePlayerReferences: dummy references.	"for shared References table"
	replacements _ dummy blockers.
	dummy project ifNil: [self error: 'lost the project!'].
	dummy project class == DiskProxy ifTrue: [self error: 'saving the wrong project'].
	dummy _ nil.	"force GC?"
	naughtyBlocks _ arrayOfRoots select: [ :each |
		(each isKindOf: ContextPart) and: [each hasInstVarRef]
	].
	naughtyBlocks isEmpty ifFalse: [
		goodToGo _ PopUpMenu
			confirm: 
'Some block(s) which reference instance variables 
are included in this segment. These may fail when
the segment is loaded if the class has been reshaped.
What would you like to do?' 
			trueChoice: 'keep going' 
			falseChoice: 'stop and take a look'.
		goodToGo ifFalse: [
			naughtyBlocks inspect.
			self error: 'Here are the bad blocks'].
	].

	"Creation of the segment happens here"

	"try using one-quarter of memory to publish (will get bumped later)"
	self copyFromRoots: arrayOfRoots sizeHint: (Smalltalk garbageCollect // 4 // 4) areUnique: true.
	segSize _ segment size.
	[(newRoots _ self rootsIncludingBlockMethods) == nil] whileFalse: [
		arrayOfRoots _ newRoots.
		self copyFromRoots: arrayOfRoots sizeHint: segSize areUnique: true].
		"with methods pointed at from outside"
	[(newRoots _ self rootsIncludingBlocks) == nil] whileFalse: [
		arrayOfRoots _ newRoots.
		self copyFromRoots: arrayOfRoots sizeHint: segSize areUnique: true].
		"with methods, blocks from outPointers"
	list _ self compactClassesArray.
	outPointers _ outPointers, ((list select: [:cls | cls ~~ nil]), (Array with: 1717 with: list)).
	1 to: outPointers size do: [:ii | 
		(outPointers at: ii) class == BlockContext ifTrue: [outPointers at: ii put: nil].
		(outPointers at: ii) class == MethodContext ifTrue: [outPointers at: ii put: nil].
		"substitute new object in outPointers"
		(replacements includesKey: (outPointers at: ii)) ifTrue: [
			outPointers at: ii put: (replacements at: (outPointers at: ii))]].
	symbolHolder.