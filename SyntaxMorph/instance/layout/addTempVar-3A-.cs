addTempVar: aMorph 
	"know we are a block inside a MethodNode" 
	"(aMorph nodeClassIs: TempVariableNode) is known to be true."
	| tempHolder ii tt var nn |
	tempHolder _ (ii _ owner submorphIndexOf: self) = 1
				ifFalse: [tt _ owner submorphs at: ii - 1.
						(tt isSyntaxMorph and: [tt nodeClassIs: MethodTempsNode])
					 		ifTrue: [tt] ifFalse: [nil]]
				ifTrue: [nil].
	nn _ aMorph parseNode key.	"name"

	tempHolder ifNil: [
		tempHolder _ owner addRow: #tempVariable on: MethodTempsNode new.
		owner addMorph: tempHolder inFrontOf: self.
		aMorph parseNode name: nn key: nn code: nil.
		aMorph parseNode asMorphicSyntaxIn: tempHolder.
		tempHolder cleanupAfterItDroppedOnMe.
		^ true].

	tempHolder submorphsDo:
		[:m | m isSyntaxMorph and: [m parseNode key = nn ifTrue: [^ false]]].
	aMorph parseNode name: nn key: nn code: nil.
	tempHolder addMorphBack: (tempHolder transparentSpacerOfSize: 4@4).
	var _ tempHolder addColumn: #tempVariable on: aMorph parseNode.
	var layoutInset: 1.
	var addMorphBack: (self addString: nn).
	var cleanupAfterItDroppedOnMe.
	^ true