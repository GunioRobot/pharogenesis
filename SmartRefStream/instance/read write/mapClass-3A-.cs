mapClass: incoming
	"See if the old class named nm exists.  If so, return it.  If not, map it to a new class, and save the mapping in renamed.  "

	| cls oldVer sel nm |
	nm _ renamed at: incoming ifAbsent: [incoming].	"allow pre-mapping around collisions"
	(nm endsWith: ' class') 
		ifFalse: [cls _ Smalltalk at: nm ifAbsent: [nil].
			cls ifNotNil: [^ cls]]  	"Known class.  It will know how to translate the instance."
		ifTrue: [cls _ Smalltalk at: nm substrings first asSymbol ifAbsent: [nil].
			cls ifNotNil: [^ cls class]]. 	"Known class.  It will know how to translate the instance."
	oldVer _ self versionSymbol: (structures at: nm).
	sel _ nm asString.
	sel at: 1 put: (sel at: 1) asLowercase.
	sel _ sel, oldVer.	"i.e. #rectangleoc4"
	Symbol hasInterned: sel ifTrue: [:symb | 
		(self class canUnderstand: sel asSymbol) ifTrue: [
			cls _ self perform: sel asSymbol]].	"This class will take responsibility"
	cls ifNotNil: [
			renamed at: nm put: cls name.
			^ cls].
	"Never heard of it!"
	^ self writeClassRenameMethod: sel was: nm
				fromInstVars: (structures at: nm).
