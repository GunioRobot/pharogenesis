readSingleFieldNodeFrom: aVRMLStream
	"This method was automatically generated"
	aVRMLStream backup.
	aVRMLStream readName = 'NULL' ifTrue:[
		aVRMLStream discard.
		^nil].
	aVRMLStream restore.
	^self parseStatement: aVRMLStream