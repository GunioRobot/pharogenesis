parseStatement: aVRMLStream
	| token |
	aVRMLStream skipSeparators.
	token := aVRMLStream readName.
	(VRMLStatements includesKey: token) ifTrue:[
		^self dispatchOn: token in: VRMLStatements with: aVRMLStream ifNone:[]].
	(nodeTypes includesKey: token) ifTrue:[
		infoBar value: (aVRMLStream position * 100 // aVRMLStream size).
		^(nodeTypes at: token) readFrom: aVRMLStream in: self].
	self error:'Unkown token'.