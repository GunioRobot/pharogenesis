checkForPaths: anObject
	"After an object is fully internalized, it should have no PathFromHome in it.	The only exception is Array, as pointed to by an IncomingObjects.  "
	| pfh |
	pfh _ Smalltalk at: #PathFromHome ifAbsent: [^ self].
	1 to: anObject class instSize do:
		[:i | (anObject instVarAt: i) class == pfh ifTrue: [
			self error: 'Unresolved Path']].
