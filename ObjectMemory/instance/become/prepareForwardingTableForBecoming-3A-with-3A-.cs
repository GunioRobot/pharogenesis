prepareForwardingTableForBecoming: array1 with: array2
	"Ensure that there are enough forwarding blocks to accomodate this become, then prepare forwarding blocks for the pointer swap. Return true if successful."
	"Details: Doing a GC might generate enough space for forwarding blocks if we're short. However, this is an uncommon enough case that it is better handled by primitive fail code at the Smalltalk level."

	| entriesNeeded entriesAvailable fieldOffset oop1 oop2 fwdBlock |
	entriesNeeded _ 2 * ((self lastPointerOf: array1) // 4).  "need enough entries for both directions"
	entriesAvailable _ self fwdTableInit.
	entriesAvailable < entriesNeeded ifTrue: [
		self initializeMemoryFirstFree: freeBlock.  "re-initialize the free block"
		^ false
	].

	fieldOffset _ self lastPointerOf: array1.
	[fieldOffset >= BaseHeaderSize] whileTrue: [
		oop1 _ self longAt: array1 + fieldOffset.
		oop2 _ self longAt: array2 + fieldOffset.
		fwdBlock _ self fwdBlockGet.
		self initForwardBlock: fwdBlock mapping: oop1 to: oop2.
		fwdBlock _ self fwdBlockGet.
		self initForwardBlock: fwdBlock mapping: oop2 to: oop1.
		fieldOffset _ fieldOffset - 4.
	].
	^ true