example1
	"self example1"
	Analyzer externalReferenceOf: (#(#Object #Behavior #ClassDescription #Class )
			collect: [:clsname | Smalltalk at: clsname]) inspect 