testInitializeIsCallOnceWhensubclassIsCreated
	"self debug: #testInitializeIsCallOnceWhensubclassIsCreated"

	ObjectWithInitialize
		subclass: #ObjectWithInitializeSubclass
		instanceVariableNames: ' '
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Tests-KCP'.
	self assert: ObjectWithInitialize classVar =1.