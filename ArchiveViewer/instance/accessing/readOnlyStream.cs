readOnlyStream
	"Answer a read-only stream on the selected member.
	For the various stream-reading services."

	^self selectedMember ifNotNilDo: [ :mem | mem contentStream ascii ]