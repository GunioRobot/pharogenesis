setGraphic: aGraphicalObject
	aGraphicalObject isForm ifTrue:[
		^self setTexturePointer: aGraphicalObject.
	].
	aGraphicalObject isMorph ifTrue:[
		^aGraphicalObject installAsWonderlandTextureOn: self.
	].