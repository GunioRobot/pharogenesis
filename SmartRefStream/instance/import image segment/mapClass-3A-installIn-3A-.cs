mapClass: newClass installIn: mapFakeClassesToReal
	"aClass is has already been mapped!  Make a fake class for the old shape.  Write it into the dictionary mapping Fake classes to Real classes."

	| newName className oldInstVars fakeClass |
	newClass isMeta ifTrue: [^ nil].
	newName _ newClass name.
	className _ renamed keyAtValue: newName ifAbsent: [newName].
		"A problem here if two classes map to the same one!"
	(steady includes: newClass) ifTrue: [^ nil].
	oldInstVars _ structures at: className ifAbsent: [
			self error: 'class is not in structures list'].	"Missing in object file"
	fakeClass _ Object subclass: ('Fake37',className) asSymbol
		instanceVariableNames: oldInstVars allButFirst
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Obsolete'.
	mapFakeClassesToReal at: fakeClass put: newClass.
	^ fakeClass
