, aSequenceableCollection 
	"Answer a copy of the receiver with each element of the argument, 
	aSequencableCollection, added, in order."
	
	^self copyReplaceFrom: self size + 1
		  to: self size
		  with: aSequenceableCollection