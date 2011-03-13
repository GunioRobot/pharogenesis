copy: aClassNode
	| newName newClass |
	newName := OBTextRequest
			prompt: 'Please type new class name'
			template: aClassNode theNonMetaClassName asString.
	newName ifNotNil:	[newClass := self
										copyClass: aClassNode theNonMetaClass 
										as: newName asSymbol.
						(newClass asNode) signalSelection].