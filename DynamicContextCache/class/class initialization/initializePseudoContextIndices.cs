initializePseudoContextIndices
	"Assumes: InterpreterCore has already been initialised."

	"Notes:	this permits a quick test for a pseudo context (the sender field contains
			an integer object)."

	CachedContextIndex _ SenderIndex.