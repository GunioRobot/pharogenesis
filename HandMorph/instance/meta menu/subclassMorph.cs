subclassMorph
	"Create a new subclass of this morph's class and make this morph be an instance of it."

	| m oldClass newClassName newClass newMorph |
	m _ argument.
	oldClass _ m class.
	newClassName _ FillInTheBlank
		request: 'Please give this new class a name'
		initialAnswer: oldClass name.
	newClassName = '' ifTrue: [^ self].
	(Smalltalk includesKey: newClassName)
		ifTrue: [^ self inform: 'Sorry, there is already a class of that name'].

	newClass _ oldClass subclass: newClassName asSymbol
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: oldClass category asString.
	newMorph _ m as: newClass.
	m become: newMorph.
