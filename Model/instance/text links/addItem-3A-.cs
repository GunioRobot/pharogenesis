addItem: classAndMethod
	"Make a linked message list and put this method in it"
	| list |

	self flag: #mref.	"classAndMethod is a String"

	MessageSet 
		parse: classAndMethod  
		toClassAndSelector: [ :class :sel |
			class ifNil: [^self].
			list _ OrderedCollection with: (
				MethodReference new
					setClass: class  
					methodSymbol: sel 
					stringVersion: classAndMethod
			).
			MessageSet 
				openMessageList: list 
				name: 'Linked by HyperText'.
		]

