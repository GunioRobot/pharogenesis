screenForm

	| screenImage colorMap pickValue elseValue |
	screenForm ifNotNil: [^ screenForm].
	passElseBlock ifNil: [passElseBlock _ true].
	passingColor ifNil: [passingColor _ Color black].
	passElseBlock
		ifTrue: [pickValue _ 16rFFFFFFFF.  elseValue _ 0]
		ifFalse: [pickValue _ 0.  elseValue _ 16rFFFFFFFF].
	screenImage _ self screenMorph imageFormForRectangle: self screenMorph bounds.
	colorMap _ screenImage newColorMap atAllPut: elseValue.
	colorMap at: (passingColor indexInMap: colorMap) put: pickValue.
	screenForm _ Form extent: screenImage extent.
	screenForm copyBits: screenForm boundingBox
			from: screenImage at: 0@0 colorMap: colorMap.
	^ screenForm