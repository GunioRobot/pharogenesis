exportClassesNamed: classNameList to: aFileName

	| classList |
	classList _ OrderedCollection new.
	classNameList do: [:nm | classList add: (Smalltalk at: nm); add: (Smalltalk at: nm) class].
	self exportCodeSegment: aFileName classes: classList keepSource: true