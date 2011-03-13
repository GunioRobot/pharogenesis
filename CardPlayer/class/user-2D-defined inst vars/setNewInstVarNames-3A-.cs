setNewInstVarNames: listOfStrings
	"Make listOfStrings be the new list of instance variable names for the receiver"

	| disappearing firstAppearing instVarString instVarList |
	instVarList _ self instVarNames asOrderedCollection.
	disappearing _ instVarList copy.
	disappearing removeAllFoundIn: listOfStrings.
	disappearing do:
		[:oldName | 	self removeAccessorsFor: oldName].
	firstAppearing _ listOfStrings copy.
	firstAppearing removeAllFoundIn: instVarList.
	firstAppearing do:
		[:newName | self compileAccessorsFor: newName].
	instVarString _ String streamContents:
		[:aStream | listOfStrings do: [:aString | aStream nextPutAll: aString; nextPut: $ ]].

	superclass subclass: self name instanceVariableNames: instVarString 
		classVariableNames: '' poolDictionaries: '' category: self categoryForUniclasses
