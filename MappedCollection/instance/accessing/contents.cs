contents
	"Answer the receiver's domain for mapping, a Dictionary or 
	SequenceableCollection."

	^map collect: [:mappedIndex | domain at: mappedIndex]