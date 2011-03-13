rename: aClassNode
	| newName |
	newName := OBTextRequest
					prompt: 'Please type new class name' 
					template: aClassNode theNonMetaClassName asString.
	newName ifNotNil:	[ | oldName |
						oldName := aClassNode theNonMetaClass name.
						aClassNode theNonMetaClass environment 
							renameClassNamed: oldName
							as: newName asSymbol.
						self browseObsoleteRefs: aClassNode as: oldName].
	