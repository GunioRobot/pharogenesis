elementTypeFor: aStringOrSymbol
	"Answer a symbol characterizing what kind of element aStringOrSymbol represents.  Realistically, at present, this always just returns #systemScript; a prototyped but not-incorporated architecture supported use of a leading colon to characterize an inst var of a system class, and for the moment we still see its remnant here."

	^ (aStringOrSymbol first == $:) ifTrue: [#systemSlot] ifFalse: [#systemScript]