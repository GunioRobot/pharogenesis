systemSlotNamesOfType: aType
	"Answer the type of the slot name, or nil if not found."
	
	| aList |
	self flag: #deferred.  "Hard-coded etoyVocabulary needed here to make this work."
	aList := OrderedCollection new.
	Vocabulary eToyVocabulary methodInterfacesDo:
		 [:anInterface |
			anInterface resultType = aType ifTrue:
				[aList add: anInterface selector]].
	^ aList