interfaceClass
	"return the class to use for the Celeste interface"
	^UseScaffoldingInterface ifTrue: [ ScaffoldingCeleste ] ifFalse: [ GeneralCeleste ].