example2
	"self example2"
	(Analyzer 
		externalReferenceOf: (#(#Behavior #ClassDescription #Class )
				collect: [:clsname | Smalltalk at: clsname])) inspect