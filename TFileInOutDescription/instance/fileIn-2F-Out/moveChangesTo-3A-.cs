moveChangesTo: newFile 
	"Used in the process of condensing changes, this message requests that 
	the source code of all methods of the receiver that have been changed 
	should be moved to newFile."

	| changes |
	changes := self methodDict keys select: [:sel |
		(self compiledMethodAt: sel) fileIndex > 1 and: [
			(self includesLocalSelector: sel) or: [
				(self compiledMethodAt: sel) sendsToSuper]]].
	self
		fileOutChangedMessages: changes
		on: newFile
		moveSource: true
		toFile: 2