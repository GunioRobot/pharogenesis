readMembersFrom: stream named: fileName
	| newMember signature |
	[
		newMember _ self memberClass newFromZipFile: stream named: fileName.
		signature _ self readSignatureFrom: stream.
		signature = EndOfCentralDirectorySignature ifTrue: [ ^self ].
		signature = CentralDirectoryFileHeaderSignature
			ifFalse: [ self error: 'bad CD signature at ', (stream position - 4) hex ].
		newMember readFrom: stream.
		newMember looksLikeDirectory ifTrue: [ newMember _ newMember asDirectory ].
		self addMember: newMember.
	] repeat.