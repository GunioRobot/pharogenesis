flushBlock: lastBlock
	"Send the current block"
	| lastFlag bitsRequired method bitsSent
	storedLength fixedLength dynamicLength 
	blTree lTree dTree blBits blFreq |

	lastFlag _ lastBlock ifTrue:[1] ifFalse:[0].

	"Compute the literal/length and distance tree"
	lTree _ ZipEncoderTree buildTreeFrom: literalFreq maxDepth: MaxBits.
	dTree _ ZipEncoderTree buildTreeFrom: distanceFreq maxDepth: MaxBits.

	"Compute the bit length tree"
	blBits _ lTree bitLengths, dTree bitLengths.
	blFreq _ WordArray new: MaxBitLengthCodes.
	self scanBitLengths: blBits into: blFreq.
	blTree _ ZipEncoderTree buildTreeFrom: blFreq maxDepth: MaxBitLengthBits.

	"Compute the bit length for the current block.
	Note: Most of this could be computed on the fly but it's getting
	really ugly in this case so we do it afterwards."
	storedLength _ self storedBlockSize.
	fixedLength _ self fixedBlockSizeFor: lTree and: dTree.
	dynamicLength _ self dynamicBlockSizeFor: lTree and: dTree 
							using: blTree and: blFreq.
	VerboseLevel > 1 ifTrue:[
		Transcript cr; show:'Block sizes (S/F/D):';
			space; print: storedLength // 8; 
			nextPut:$/; print: fixedLength // 8; 
			nextPut:$/; print: dynamicLength // 8; space; endEntry].

	"Check which method to use"
	method _ self forcedMethod.
	method == nil ifTrue:[
		method _ (storedLength < fixedLength and:[storedLength < dynamicLength]) 
			ifTrue:[#stored]
			ifFalse:[fixedLength < dynamicLength ifTrue:[#fixed] ifFalse:[#dynamic]]].
	(method == #stored and:[blockStart < 0]) ifTrue:[
		"Cannot use #stored if the block is not available"
		method _ fixedLength < dynamicLength ifTrue:[#fixed] ifFalse:[#dynamic]].

	bitsSent _ encoder bitPosition. "# of bits sent before this block"
	bitsRequired _ nil.

	(method == #stored) ifTrue:[
		VerboseLevel > 0 ifTrue:[Transcript show:'S'].
		bitsRequired _ storedLength.
		encoder nextBits: 3 put: StoredBlock << 1 + lastFlag.
		self sendStoredBlock].

	(method == #fixed) ifTrue:[
		VerboseLevel > 0 ifTrue:[Transcript show:'F'].
		bitsRequired _ fixedLength.
		encoder nextBits: 3 put: FixedBlock << 1 + lastFlag.
		self sendFixedBlock].

	(method == #dynamic) ifTrue:[
		VerboseLevel > 0 ifTrue:[Transcript show:'D'].
		bitsRequired _ dynamicLength.
		encoder nextBits: 3 put: DynamicBlock << 1 + lastFlag.
		self sendDynamicBlock: blTree 
			literalTree: lTree 
			distanceTree: dTree 
			bitLengths: blBits].

	bitsRequired = (encoder bitPosition - bitsSent)
		ifFalse:[self error:'Bits size mismatch'].

	lastBlock 
		ifTrue:[self release]
		ifFalse:[self initializeNewBlock].