mappedBy: aSequenceableCollection 
	"Answer a MappedCollection whose contents is the receiver and whose 
	map is the argument, aSequencableCollection."

	^(MappedCollection collection: self map: aSequenceableCollection) contents