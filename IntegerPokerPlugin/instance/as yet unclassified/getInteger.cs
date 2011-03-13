getInteger

	| stringOop stringData integer locationOop location |
	self export: true.
	self var: #stringData declareC: 'unsigned char *stringData'.
	self var: #location declareC: 'int location'.


	"decode the string to read it from"
	stringOop := (interpreterProxy stackValue: 1).
	(interpreterProxy isBytes: stringOop ) ifFalse: [
		interpreterProxy success: false.  ^nil ].
	stringData := (interpreterProxy arrayValueOf: stringOop).


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

	"do the retrieval"
	integer := (stringData at: location) asInteger << 24.
	integer := (stringData at: location+1) asInteger << 16 + integer.
	integer := (stringData at: location+2) asInteger << 8 + integer.
	integer := (stringData at: location+3) asInteger + integer.

	"convert it to a negative number, if it's too large"
	integer > (self cutOffForPositives) ifTrue: [
		integer := (self cutOffForPositives) - integer ].

	"push the result"
	interpreterProxy pop: 2.
	interpreterProxy pushInteger: integer.