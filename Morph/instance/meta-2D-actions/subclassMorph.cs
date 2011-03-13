subclassMorph
	"Create a new subclass of this morph's class and make this morph be an instance of it."

	| oldClass newClassName newClass newMorph |
	oldClass := self class.
	newClassName := UIManager default
		request: 'Please give this new class a name' translated
		initialAnswer: oldClass name.
	newClassName isEmptyOrNil ifTrue: [^ self].
	(Smalltalk includesKey: newClassName)
		ifTrue: [^ self inform: 'Sorry, there is already a class of that name'].

	newClass := oldClass subclass: newClassName asSymbol
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: oldClass category asString.
	newMorph := self as: newClass.
	self become: newMorph.
