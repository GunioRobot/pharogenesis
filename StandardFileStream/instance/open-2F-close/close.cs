close
	"Close this file."

	fileID ifNotNil: [
		self primClose: fileID.
		self unregister.
		fileID _ nil].
