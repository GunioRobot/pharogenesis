preludeString
	^'"Change Set:		Balloon3D
Date:			', Date today printString,'
Author:			', Utilities authorName,'

This is the base change set for installing the full Balloon3D package.
"
InterpreterPlugin ifNil:[
	Object subclass: #InterpreterPlugin
		instanceVariableNames: ''interpreterProxy moduleName''
		classVariableNames: ''''
		poolDictionaries: ''''
		category: ''VMConstruction-Plugins''
].

Smalltalk at: #WonderlandConstants ifAbsentPut:[Dictionary new].

'.