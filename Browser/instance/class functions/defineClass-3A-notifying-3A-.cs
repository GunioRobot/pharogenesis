defineClass: defString notifying: aController 
	"The receiver's textual content is a request to define a new class. The 
	source code is defString. If any errors occur in compilation, notify 
	aController."
	| oldClass class newClassName defTokens keywdIx envt |
	oldClass _ self selectedClassOrMetaClass.
	defTokens _ defString findTokens: Character separators.
	keywdIx _ defTokens indexOf: 'category:'.
	envt _ Smalltalk environmentForCategory: ((defTokens at: keywdIx+1) copyWithout: $').
	keywdIx _ defTokens findFirst: [:x | x endsWith: 'ubclass:'].
	newClassName _ (defTokens at: keywdIx+1) copyWithout: $#.
	((oldClass isNil or: [oldClass name asString ~= newClassName])
		and: [envt includesKeyOrAbove: newClassName asSymbol]) ifTrue:
			["Attempting to define new class over existing one when
				not looking at the original one in this browser..."
			(self confirm: ((newClassName , ' is an existing class in this system.
Redefining it might cause serious problems.
Is this really what you want to do?') asText makeBoldFrom: 1 to: newClassName size))
				ifFalse: [^ false]].
	"ar 8/29/1999: Use oldClass superclass for defining oldClass
	since oldClass superclass knows the definerClass of oldClass."
	oldClass ifNotNil:[oldClass _ oldClass superclass].
	class _ oldClass subclassDefinerClass
				evaluate: defString
				notifying: aController
				logged: true.
	(class isKindOf: Behavior)
		ifTrue: 
			[self changed: #classList.
			self classListIndex: 
				(self classList indexOf: 
					((class isKindOf: Metaclass)
						ifTrue: [class soleInstance name]
						ifFalse: [class name])).
			self clearUserEditFlag; editClass.
			^true]
		ifFalse: [^false]