initializeMessageList: anArray
	"Initialize my messageList from the given list of MethodReference or string objects.  NB: special handling for uniclasses."

	| s |
	messageList _ OrderedCollection new.
	anArray do: [ :each |
		MessageSet 
			parse: each  
			toClassAndSelector: [ :class :sel |
				class ifNotNil:
					[class isUniClass
						ifTrue:
							[s _ class typicalInstanceName, ' ', sel]
						ifFalse:
							[s _ class name , ' ' , sel , ' {' , 
								((class organization categoryOfElement: sel) ifNil: ['']) , '}'].
					messageList add: (
						MethodReference new
							setClass: class  
							methodSymbol: sel 
							stringVersion: s)]]].
	messageListIndex _ messageList isEmpty ifTrue: [0] ifFalse: [1].
	contents _ ''