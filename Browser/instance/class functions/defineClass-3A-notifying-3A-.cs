defineClass: aString notifying: aController 
	"The receiver's textual content is a request to define a new class. The 
	source code is aString. If any errors occur in compilation, notify 
	aController."

	| oldClass class |
	oldClass _ self selectedClassOrMetaClass.
	oldClass isNil ifTrue: [oldClass _ Object].
	class _ oldClass subclassDefinerClass
				evaluate: aString
				notifying: aController
				logged: true.
	(class isKindOf: Behavior)
		ifTrue: 
			[self changed: #classListChanged.
			self classListIndex: 
				(self classList indexOf: 
					((class isKindOf: Metaclass)
						ifTrue: [class soleInstance name]
						ifFalse: [class name])).
			self unlock; editClass.
			^true]
		ifFalse: [^false]