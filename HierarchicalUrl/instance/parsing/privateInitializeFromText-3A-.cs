privateInitializeFromText: aString

	| remainder ind nextTok s specifiedSchemeName |
	remainder _ aString.

	schemeName ifNil: [ 
		specifiedSchemeName _ Url schemeNameForString: remainder.
		specifiedSchemeName ifNotNil: [ 
			schemeName _ specifiedSchemeName.
			remainder _ remainder copyFrom: (schemeName size+2) to: remainder size ].
		schemeName ifNil: [ "assume HTTP"  schemeName _ 'http' ] ].

	"remove leading // if it's there"
	(remainder beginsWith: '//') ifTrue: [
		remainder _ remainder copyFrom: 3 to: remainder size ].


	"get the query"
	ind _ remainder indexOf: $?.
	ind > 0 ifTrue: [
		query _ (remainder copyFrom: ind+1 to: remainder size).
		remainder _ remainder copyFrom: 1 to: ind-1 ].

	"get the authority"
	ind _ remainder indexOf: $/.
	ind > 0 ifTrue: [
		ind = 1 ifTrue: [ authority _ '' ] ifFalse: [
			authority _ remainder copyFrom: 1 to: ind-1.
			remainder _ remainder copyFrom: ind+1 to: remainder size. ] ]
	ifFalse: [
		authority _ remainder.
		remainder _ ''. ].

	"Extract the port"
	(authority includes: $:)
		ifTrue: [
			port _ (authority copyFrom: (authority indexOf: $:) + 1 to: authority size) asNumber.
			authority _ authority copyUpTo: $:].

	"get the path"
	path _ OrderedCollection new.
	s _ ReadStream on: remainder.
	[ 
		s peek = $/ ifTrue: [ s next ].
		nextTok _ WriteStream on: String new.
		[ s atEnd or: [ s peek = $/ ] ] whileFalse: [ nextTok nextPut: s next ].
		nextTok _ nextTok contents unescapePercents.
		nextTok = '..' 
			ifTrue: [ path size > 0 ifTrue: [ path removeLast ] ]
			ifFalse: [ nextTok ~= '.' ifTrue: [ path add: nextTok ] ].
		s atEnd 
	] whileFalse.
	path isEmpty ifTrue: [ path add: '' ].