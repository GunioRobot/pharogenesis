emitCCodeOn: aStream level: level generator: aCodeGen

	name = 'nil'
		ifTrue: [ aStream nextPutAll: (aCodeGen cLiteralFor: nil) ]
		ifFalse: [ aStream nextPutAll: name ].