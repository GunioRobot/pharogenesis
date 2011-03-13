modified: aBoolean
     modified = aBoolean ifTrue: [^ self].
	modified := aBoolean.
	self changed: #modified.
	
	modified ifFalse:
		[(((Smalltalk classNamed: 'SmalltalkImage') ifNotNilDo: [:si | si current]) ifNil: [Smalltalk])
			logChange: '"', self packageName, '"'].