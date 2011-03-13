asMorphicSyntaxIn: parent

	| printer substitute row sel |
	sel _ #message.
	((parent nodeClassIs: CascadeNode) and: [parent parseNode receiver ~~ self]) ifTrue: [
		sel _ #keyword2.
		receiver ifNotNil: [self inform: 'receiver should be nil']].
	row _ parent addRow: sel on: self.
	special > 0 ifTrue: [printer _ MacroPrinters at: special].
	substitute _ self as: TileMessageNode.
	(printer == #printCaseOn:indent:) ifTrue: [
		self asMorphicCaseOn: row indent: nil.
		^ parent].
	(special > 0)
		ifTrue: 
			[substitute perform: printer with: row with: nil]
		ifFalse: 
			[substitute 
				printKeywords: selector key
				arguments: arguments
				on: row
				indent: nil].
	^ row addTransparentSpacerOfSize: 3@10.
