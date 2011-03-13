checkForPaths: anObject
	"After an object is fully internalized, it should have no PathFromHome in it.	The only exceptiuon in Array, as pointed to by an IncomingObjects.  8/16/96 tk"

	1 to: anObject class instSize do:
		[:i | (anObject instVarAt: i) class == PathFromHome ifTrue: [
			self error: 'Unresolved Path']].
