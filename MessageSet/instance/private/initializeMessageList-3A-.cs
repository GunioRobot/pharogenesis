initializeMessageList: anArray
	"Initialize my messageList from the given list of MethodReference or string objects.  NB: special handling for uniclasses."

	| s |
	messageList := OrderedCollection new.
	anArray do: [ :each |
		MessageSet 
			parse: each  
			toClassAndSelector: [ :class :sel |
				class ifNotNil:
					[class isUniClass
						ifTrue:
							[s := class typicalInstanceName, ' ', sel]
						ifFalse:
							[s := class name , ' ' , sel , ' {' , 
								((class organization categoryOfElement: sel) ifNil: ['']) , '}'].
					messageList add: (
						MethodReference new
							setClass: class  
							methodSymbol: sel 
							stringVersion: s)]]].
	messageListIndex := messageList isEmpty ifTrue: [0] ifFalse: [1].
	contents := ''