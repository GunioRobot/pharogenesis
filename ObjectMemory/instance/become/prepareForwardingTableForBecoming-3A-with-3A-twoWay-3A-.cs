prepareForwardingTableForBecoming: array1 with: array2 twoWay: twoWayFlag
	"Ensure that there are enough forwarding blocks to accomodate this become, then prepare forwarding blocks for the pointer swap. Return true if successful."
	"Details: Doing a GC might generate enough space for forwarding blocks if we're short. However, this is an uncommon enough case that it is better handled by primitive fail code at the Smalltalk level."

	| entriesNeeded entriesAvailable fieldOffset oop1 oop2 fwdBlock fwdBlkSize |
	entriesNeeded _ (self lastPointerOf: array1) // 4.  "need enough entries for all oops"
	twoWayFlag
		ifTrue: ["Double the number of blocks for two-way become"
				entriesNeeded _ entriesNeeded * 2.
				fwdBlkSize _ 8  "Note: Forward blocks must be quadword aligned."]
		ifFalse: ["One-way become needs backPointers in fwd blocks."
				fwdBlkSize _ 16  "Note: Forward blocks must be quadword aligned."].
	entriesAvailable _ self fwdTableInit: fwdBlkSize.
	entriesAvailable < entriesNeeded ifTrue: 
		[self initializeMemoryFirstFree: freeBlock.  "re-initialize the free block"
		^ false].

	fieldOffset _ self lastPointerOf: array1.
	[fieldOffset >= BaseHeaderSize] whileTrue: 
		[oop1 _ self longAt: array1 + fieldOffset.
		oop2 _ self longAt: array2 + fieldOffset.
		fwdBlock _ self fwdBlockGet: fwdBlkSize.
		self initForwardBlock: fwdBlock mapping: oop1 to: oop2 withBackPtr: twoWayFlag not.
		twoWayFlag ifTrue:
			["Second block maps oop2 back to oop1 for two-way become"
			fwdBlock _ self fwdBlockGet: fwdBlkSize.
			self initForwardBlock: fwdBlock mapping: oop2 to: oop1 withBackPtr: twoWayFlag not].
		fieldOffset _ fieldOffset - 4].
	^ true