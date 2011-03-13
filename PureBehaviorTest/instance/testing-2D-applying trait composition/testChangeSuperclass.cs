testChangeSuperclass
	"self run: #testChangeSuperclass"

	"Test that when the superclass of a class is changed the non-local methods
	of the class sending super are recompiled to correctly store the new superclass."

	| aC2 newSuperclass |
	aC2 := self c2 new.

	"C1 is current superclass of C2"
	self assert: aC2 m51.
	self assert: self c2 superclass == self c1.
	self deny: (self c2 localSelectors includes: #m51).

	"change superclass of C2 from C1 to X"
	newSuperclass := self createClassNamed: #X superclass: Object uses: {}.
	newSuperclass
		subclass: self c2 name
		uses: self c2 traitComposition
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: self c2 category.

	self assert: self c2 superclass == newSuperclass.

	newSuperclass compile: 'foo ^17'.
	self assert: aC2 m51 = 17.
	self deny: (self c2 localSelectors includes: #m51).

	self c2 compile: 'm51 ^19'.
	self assert: aC2 m51 = 19.

	"Other methods than those sending super should not have been recompiled"
	self assert: self c2 >> #m52 == (self t5 >> #m52).

	
	