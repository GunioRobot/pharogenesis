removeMessage
	"Remove the selected msg from the system.  Real work done by the parent, a ChangeSorter"

	| confirmation sel |
	self okToChange ifFalse: [^ self].
	currentSelector ifNotNil: [
		confirmation _ self selectedClassOrMetaClass 
			confirmRemovalOf: (sel _ self selectedMessageName).
		confirmation == 3 ifTrue: [^ self].
		self selectedClassOrMetaClass removeSelector: sel.
		self update.
		confirmation == 2 ifTrue:
			[Smalltalk browseAllCallsOn: sel]]