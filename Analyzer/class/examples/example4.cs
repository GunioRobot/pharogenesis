example4 
	"self example4"
	(((Analyzer
		externalReferenceOf: (#(#Object #Behavior #ClassDescription #Class )
				collect: [:clsname | Smalltalk at: clsname]))
		select: [:clsName | (Smalltalk includesKey: clsName)
				and: [(Smalltalk at: clsName)
						isKindOf: Class]])
		select: [:clssName | ((Smalltalk at: clssName) category asString beginsWith: 'Kernel') not]) inspect