fileOutOn: stream 
	"Write out all the changes the receiver knows about"

	| classList |
	(self isEmpty and: [stream isKindOf: FileStream])
		ifTrue: [self inform: 'Warning: no changes to file out'].
	classList _ ChangeSet superclassOrder: self changedClasses asOrderedCollection.

	"First put out rename, max classDef and comment changes."
	classList do: [:aClass | self fileOutClassDefinition: aClass on: stream].

	"Then put out all the method changes"
	classList do: [:aClass | self fileOutChangesFor: aClass on: stream].

	"Finally put out removals, final class defs and reorganization if any"
	classList reverseDo: [:aClass | self fileOutPSFor: aClass on: stream].

	self classRemoves asSortedCollection do:
		[:aClassName | stream nextChunkPut: 'Smalltalk removeClassNamed: #', aClassName; cr].