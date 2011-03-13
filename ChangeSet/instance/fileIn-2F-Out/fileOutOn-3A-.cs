fileOutOn: stream 
	"Write out all the changes the receiver knows about.
	 5/15/96 sw: changed such that class headers for all changed classes go out at the beginning of the file."

	| classList |
	self isEmpty ifTrue: [self notify: 'Warning: no changes to file out'].
	classList _ ChangeSet superclassOrder: self changedClasses asOrderedCollection.
	classList do:
		[:aClass |  "if class defn changed, put it onto the file now"
			self fileOutClassDefinition: aClass on: stream].
	classList do:
		[:aClass |  "nb: he following no longer puts out class headers"
			self fileOutChangesFor: aClass on: stream].
	stream cr.
	classList do:
		[:aClass |
		self fileOutPSFor: aClass on: stream].
	classRemoves do:
		[:aClassName |
		stream nextChunkPut: aClassName, ' removeFromSystem'; cr].