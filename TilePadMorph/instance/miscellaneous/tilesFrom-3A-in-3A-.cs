tilesFrom: aParseNode in: aScriptor
	"Make a Pad and a Tile for a variable, self, a number, or other literal"

	| outsideObj tile |
	(aParseNode isKindOf: LiteralNode) ifTrue: [
		type _ #literal.
		^ self addMorph: (aParseNode literalValue newTileMorphRepresentative)].
	(aParseNode isKindOf: VariableNode) ifTrue: [
		aParseNode isSelfPseudoVariable ifTrue: [
			tile _ (CategoryViewer new) tileForPlayer: aScriptor playerScripted.
			type _ tile type.
			^ self addMorph: tile].
		(aParseNode key = 'true') | (aParseNode key = 'false') ifTrue: [
			type _ #literal.
			^ self addMorph: (aParseNode key first == $t) newTileMorphRepresentative]].

	(aParseNode isKindOf: MessageNode) ifTrue: [
		(self isColorConstant: aParseNode) ifTrue: [
			type _ #color.
			^ self addMorph: (aParseNode eval newTileMorphRepresentative)]].
		
	(aParseNode isKindOf: MessageNode) ifTrue: [
		(self isOutsideRef: aParseNode) ifTrue: [
			outsideObj _ aScriptor playerScripted class perform: aParseNode selector key.
			tile _ (CategoryViewer new) tileForPlayer: outsideObj.
			type _ tile type.
			^ self addMorph: tile]].

	(aParseNode isKindOf: MessageNode) ifTrue: [
		^ PhraseTileMorph new tilesFrom: aParseNode in: aScriptor].
