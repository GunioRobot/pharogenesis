hasUnacceptedEdits: aBoolean
	"Set the hasUnacceptedEdits flag to the given value. "
	aBoolean == hasUnacceptedEdits ifFalse:
		[hasUnacceptedEdits _ aBoolean.
		self changed].
	aBoolean ifFalse: [hasEditingConflicts _ false]