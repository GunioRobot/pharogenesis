update: aSymbol

	| bingo saveOwner newMorph db |

	(db _ self debugger) ifNil: [^super update: aSymbol].
	aSymbol == #contents ifTrue: [
		saveOwner _ owner.
		db removeDependent: self.
		markerMorph ifNotNil: [markerMorph delete. markerMorph _ nil].
		newMorph _ db createSyntaxMorph.
		self delete.
		saveOwner addMorph: newMorph.
		saveOwner owner setScrollDeltas.
		newMorph update: #contentsSelection.
	].
	aSymbol == #contentsSelection ifTrue: [
		markerMorph ifNil: [
			markerMorph _ RectangleMorph new.
			markerMorph
				color: Color transparent;
				borderWidth: 2;
				borderColor: Color red;
				lock.
			owner addMorphFront: markerMorph.
		].
		bingo _ parseNode rawSourceRanges keyAtValue: db pcRange ifAbsent: [nil].
		self testForNode: bingo andDo: [ :foundMorph | 
			markerMorph
				position: foundMorph position;
				extent: foundMorph extent.
			owner owner scrollIntoView: foundMorph bounds extra: 0.5.
			^self
		].
	].
	super update: aSymbol