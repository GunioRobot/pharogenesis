allEncodingNames
	"TextConverter allEncodingNames"
	| encodingNames |
	encodingNames _ Set new.
	self allSubclasses
		do: [:each | 
			| names | 
			names _ each encodingNames.
			names notEmpty
				ifTrue: [encodingNames add: names first asSymbol]].
	^encodingNames