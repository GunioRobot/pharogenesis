pragmaStatement
	"Read a single pragma statement. Parse all generic pragmas in the form of: <key1: val1 key2: val2 ...> and remember them, including primitives."
	
	| arguments keyword |
	(hereType = #keyword or: [ hereType = #word ])
		ifFalse: [  ^ self expected: 'pragma declaration' ].

	" This is a ugly hack into the compiler of the FFI package. FFI should be changed to use propre pragmas that can be parsed with the code here. "
	(here = #apicall: or: [ here = #cdecl: ])
		ifTrue: [ ^ self externalFunctionDeclaration ].

	arguments := Array new.
	keyword := self advance.
	keyword last = $: ifTrue: [
		[ arguments := arguments copyWith: self pragmaLiteral.
		  hereType = #keyword ] whileTrue: [ keyword := keyword , self advance ] ].
	keyword numArgs ~= arguments size
		ifTrue: [ ^ self expected: 'pragma argument' ].
	self addPragma: (Pragma 
		keyword: keyword asSymbol 
		arguments: arguments).
	^ true