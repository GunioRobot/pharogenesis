close
	"Close the file."

	file ifNil: [^ self].
	file
		ensureOpen;
		setToEnd;
		close.
	file _ nil.
