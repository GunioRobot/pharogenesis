putInteger

	| stringOop stringData integerOop integer locationOop location |
	self export: true.
	self var: #stringData declareC: 'unsigned char *stringData'.
	self var: #location declareC: 'int location'.


	"decode the string to store it into"
	stringOop := (interpreterProxy stackValue: 2).
	(interpreterProxy isBytes: stringOop ) ifFalse: [
		interpreterProxy success: false.  ^nil ].
	stringData := (interpreterProxy arrayValueOf: stringOop).

	"decode the integer to be stored"
	integerOop := (interpreterProxy stackValue: 1).
	(interpreterProxy isIntegerValue: integerOop) ifFalse: [
		interpreterProxy success: false.  ^nil ].
	integer := interpreterProxy integerValueOf: integerOop.


	"decode the location"
	locationOop := (interpreterProxy stackValue: 0).
	(interpreterProxy isIntegerValue: locationOop) ifFalse: [
		interpreterProxy success: false.  ^nil ].
	location := interpreterProxy integerValueOf: locationOop.
	location := location - 1.
	location < 0 ifTrue: [
		interpreterProxy success: false. ^nil ].

	"check that the string has room"
	location + 4 > (interpreterProxy stSizeOf: stringOop) ifTrue: [
		interpreterProxy success: false.  ^nil ].

	"check that the integer is reasonably sized"
	integer > (self cutOffForPositives) ifTrue: [
		interpreterProxy success: false. ^nil ].
	integer < (self cutOffForPositives) negated ifTrue: [
		interpreterProxy success: false. ^ nil ].

	"if the integer is negative, convert it to a large positive number"
	integer < 0 ifTrue: [
		integer := (self cutOffForPositives) - integer. ].

	"do the copy"
	stringData at: location+3 put: (integer \\ 256) asCharacter.
	stringData at: location+2 put: (integer >> 8 \\ 256) asCharacter.
	stringData at: location+1 put: (integer >> 16 \\ 256) asCharacter.
	stringData at: location+0 put: (integer >> 24 \\ 256) asCharacter.

	"all done"
	interpreterProxy pop: 2