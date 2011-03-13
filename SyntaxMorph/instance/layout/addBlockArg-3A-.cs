addBlockArg: aMorph
	"Add a temporary to a block or the method.  Return true if succeed"
	"(aMorph nodeClassIs: TempVariableNode) is known to be true."
	"***NOTE: This method should be combined with addTempVar:"

	| tempHolder tt var nn |
	owner isMethodNode ifTrue: [
		^ (self addTempVar: aMorph)].	"Node for them is not inside the block"
		"If exists, drop the temp in this block and let use extend it."
	tt _ self firstSubmorph.
	tempHolder _ tt firstSubmorph isSyntaxMorph 
				ifTrue: [(tt nodeClassIs: BlockArgsNode) 
							ifTrue: [tt] ifFalse: [nil]]
				ifFalse: [nil].
	nn _ aMorph parseNode key.	"name"

	tempHolder ifNil: ["make whole row"
		tempHolder _ self addRow: #blockarg1 on: (BlockArgsNode new).
		self addMorphFront: tempHolder.
		aMorph parseNode name: nn key: nn code: nil.
		var _ tempHolder addColumn: #tempVariable on: aMorph parseNode.
		var layoutInset: 1.
		var addMorphBack: (self addString: nn).
		self cleanupAfterItDroppedOnMe.
		^ true].

	tempHolder submorphsDo:
		[:m | "if present. caller adds the temp as a new line of code to be extended"
		m isSyntaxMorph and: [m parseNode key = nn ifTrue: [^ false]]].
		
	"If this variable is not present, add it"
	aMorph parseNode name: nn key: nn code: nil.
	tempHolder addMorphBack: (tempHolder transparentSpacerOfSize: 4@4).
	var _ tempHolder addColumn: #tempVariable on: aMorph parseNode.
	var layoutInset: 1.
	var addMorphBack: (StringMorph contents: nn).
	var cleanupAfterItDroppedOnMe.
	^ true
