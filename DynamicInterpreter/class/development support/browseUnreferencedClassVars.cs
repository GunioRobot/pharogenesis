browseUnreferencedClassVars
	"DynamicInterpreter browseUnreferencedClassVars"

	| msgList users pool unrefed classList |
	classList _ DynamicInterpreterSimulator allSuperclasses remove: Object; yourself.
	unrefed _ Dictionary new.
	msgList _ OrderedCollection new.
	classList do: [:thisClass |
		pool _ thisClass classPool.
		('Checking ' , thisClass printString , '...')
			displayProgressAt: Sensor cursorPoint
			from: 1 to: pool size
			during: [:bar |
			thisClass classPool keys doWithIndex: [:key :idx |
				bar value: idx.
				users _ Set new.
				classList do: [:thatClass |
					users addAll: ((thatClass whichSelectorsReferTo: (pool associationAt: key))
						collect: [:sel | thatClass name , ' ' , sel , '  (' , key , ')']).
					users addAll: ((thatClass class whichSelectorsReferTo: (pool associationAt: key))
						collect: [:sel | thatClass class name , ' ' , sel , '  (' , key , ')'])].
				users isEmpty
					ifTrue: [unrefed add: (pool associationAt: key)]
					ifFalse: [users size < 2 ifTrue: [msgList addAll: users]]]]].
	unrefed isEmpty
		ifTrue: [PopUpMenu notify: 'no unreferenced class vars']
		ifFalse: [(PopUpMenu confirm: 'inspect unrefed?')
					ifTrue: [unrefed inspect]].
	Smalltalk browseMessageList: msgList asSortedCollection name: 'suspicious class vars'.