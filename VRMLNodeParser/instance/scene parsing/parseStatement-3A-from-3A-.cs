parseStatement: token from: aVRMLStream
	(VRMLStatements includesKey: token) ifTrue:[
		^self dispatchOn: token in: VRMLStatements with: aVRMLStream ifNone:[]].
	self error:'Unkown token'.