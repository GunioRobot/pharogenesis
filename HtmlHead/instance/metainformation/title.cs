title
	"return the title, or nil if there isn't one"
	| te |
	te _ self titleEntity.
	te ifNil: [ ^nil ].
	^te textualContents