back
	"this method is added to Scamper: Aibek 4/18/99"
	currentUrlIndex > 1
		ifTrue: [
			currentUrlIndex _ currentUrlIndex - 1.
			self displayDocument: (recentDocuments at: currentUrlIndex).
		]
		ifFalse: [^ self].
