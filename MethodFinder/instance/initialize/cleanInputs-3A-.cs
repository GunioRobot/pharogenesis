cleanInputs: dataAndAnswerString
	"Find an remove common mistakes.  Complain when ill formed."

| fixed ddd rs places |
ddd _ dataAndAnswerString.
fixed _ false.

rs _ ReadStream on: ddd, ' '.
places _ OrderedCollection new.
[rs upToAll: '#true'.  rs atEnd] whileFalse: [places addFirst: rs position-4]. 
places do: [:pos | ddd _ ddd copyReplaceFrom: pos to: pos with: ''.
	fixed _ true]. 	"remove #"

rs _ ReadStream on: ddd.
places _ OrderedCollection new.
[rs upToAll: '#false'.  rs atEnd] whileFalse: [places addFirst: rs position-5]. 
places do: [:pos | ddd _ ddd copyReplaceFrom: pos to: pos with: ''.
	fixed _ true]. 	"remove #"

fixed ifTrue: [self inform: '#(true false) are Symbols, not Booleans.  
Next time use { true. false }.'].

fixed _ false.
rs _ ReadStream on: ddd.
places _ OrderedCollection new.
[rs upToAll: '#nil'.  rs atEnd] whileFalse: [places addFirst: rs position-3]. 
places do: [:pos | ddd _ ddd copyReplaceFrom: pos to: pos with: ''.
	fixed _ true]. 	"remove #"

fixed ifTrue: [self inform: '#nil is a Symbol, not the authentic UndefinedObject.  
Next time use nil instead of #nil'].

^ ddd
