extractThisVersion: list
	"Pull out the part of the list that applies to this version."

	| delims lines ii out eToySystem |
	(eToySystem _ Smalltalk at: #EToySystem ifAbsent: [nil]) ifNil: [^ #()].
	delims _ String with: Character cr with: Character linefeed.
	lines _ list findTokens: delims.
	ii _ lines indexOf: '#', eToySystem version.
	ii = 0 ifTrue: [^ #()].
	out _ OrderedCollection new.
	[(ii _ ii + 1) <= lines size] whileTrue:
		[(lines at: ii) first == $# ifTrue: [^ out "next version"].
		(lines at: ii) first == $* ifFalse: [out addLast: (lines at: ii)]].	"keep, except comments"
	^ out