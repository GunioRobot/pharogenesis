compilerClass
	^self methodClass 
		ifNil: [self class compilerClass] 
		ifNotNilDo: [:class | class compilerClass].