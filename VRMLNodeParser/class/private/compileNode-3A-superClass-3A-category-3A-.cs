compileNode: nodeSpec superClass: aClass category: aString
	| varNames theClass |
	(aClass includesBehavior: VRMLClassNode) ifFalse:[^self halt].
	varNames := WriteStream on: (String new).
	nodeSpec attributes do:[:attr|
		('event*' match: attr attrClass ) ifFalse:[
			varNames nextPutAll: (attr name copyReplaceAll:'_' with: '').
			varNames space.
		].
	].
	theClass := aClass subclass: (self vrmlClassNameFor: nodeSpec name) asSymbol
		instanceVariableNames: varNames contents
		classVariableNames: ''
		poolDictionaries: ''
		category: aString.
	theClass nodeSpec: nodeSpec.
	theClass compileAccessors.
	theClass compileEnumerator.
	nodeSpec vrmlClass: theClass.