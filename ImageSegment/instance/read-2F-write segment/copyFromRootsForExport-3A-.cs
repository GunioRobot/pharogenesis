copyFromRootsForExport: rootArray 
	"When possible, use copySmartRootsExport:.  This way may not copy a complete tree of objects.  Add to roots: all of the methods pointed to from the outside by blocks."
	| newRoots list segSize symbolHolder |
	arrayOfRoots _ rootArray.
	Smalltalk forgetDoIts.
	"self halt."
	symbolHolder _ Symbol allInstances, MultiSymbol allInstances.	"Hold onto Symbols with strong pointers, 
		so they will be in outPointers"
	(newRoots _ self rootsIncludingPlayers) ifNotNil: [
		arrayOfRoots _ newRoots].		"world, presenter, and all Player classes"
	"Creation of the segment happens here"
	self copyFromRoots: arrayOfRoots sizeHint: 0.
	segSize _ segment size.
	[(newRoots _ self rootsIncludingBlockMethods) == nil] whileFalse: [
		arrayOfRoots _ newRoots.
		self copyFromRoots: arrayOfRoots sizeHint: segSize].
		"with methods pointed at from outside"
	[(newRoots _ self rootsIncludingBlocks) == nil] whileFalse: [
		arrayOfRoots _ newRoots.
		self copyFromRoots: arrayOfRoots sizeHint: segSize].
		"with methods, blocks from outPointers"
	"classes of receivers of blocks"
	list _ self compactClassesArray.
	outPointers _ outPointers, ((list select: [:cls | cls ~~ nil]), (Array with: 1717 with: list)).
	"Zap sender of a homeContext. Can't send live stacks out."
	1 to: outPointers size do: [:ii | 
		(outPointers at: ii) class == BlockContext ifTrue: [outPointers at: ii put: nil].
		(outPointers at: ii) class == MethodContext ifTrue: [outPointers at: ii put: nil]].
	symbolHolder.