vocabularyForClass: aClass
	"Answer the standard vocabulary for that class.  Create it if not present and init message exists.  Answer nil if none exists and no init message present."

	| initMsgName newTypeVocab |
	(self allStandardVocabularies includesKey: aClass name)
		ifTrue: [^self allStandardVocabularies at: aClass name].

	initMsgName _ ('new', aClass name, 'Vocabulary') asSymbol.
	^(self respondsTo: initMsgName)
		 ifTrue:	[
			newTypeVocab _ self perform: initMsgName.
			self addStandardVocabulary: newTypeVocab.
			newTypeVocab]
		ifFalse: [nil]