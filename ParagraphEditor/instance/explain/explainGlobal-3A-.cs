explainGlobal: symbol 
	"Is symbol a global variable?"
	| reply classes |
	reply _ Smalltalk at: symbol ifAbsent: [^nil].
	(reply class == Dictionary or:[reply isKindOf: SharedPool class])
		ifTrue: 
			[classes _ Set new.
			self systemNavigation allBehaviorsDo: [:each | (each sharedPools detect: [:pool | pool == reply]
					ifNone: [])
					~~ nil ifTrue: [classes add: each]].
			classes _ classes printString.
			^'"is a global variable.  It is a pool which is used by the following classes ' , (classes allButFirst: 5) , '"'].
	(reply isKindOf: Behavior)
		ifTrue: [^'"is a global variable.  ' , symbol , ' is a class in category ', reply category,
			'."', '\' withCRs, 'Browser newOnClass: ' , symbol , '.'].
	symbol == #Smalltalk ifTrue: [^'"is a global.  Smalltalk is the only instance of SystemDictionary and holds all global variables."'].
	^'"is a global variable.  ' , symbol , ' is ' , reply printString , '"'