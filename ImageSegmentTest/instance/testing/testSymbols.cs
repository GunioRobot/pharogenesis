testSymbols
	"self debug: #testSymbols"

	"This test assures that when a symbol is stored in a segment and is loaded back into an image that already contains an instance of this symbol, no duplicate is created. At the time of this writing, this is not the case *if* the symbol is stored part of the segment rather than of the outpointers collecton. The former is the case only if no other obect than the root or an object of the subtree reachable from the root references the symbol. To reproduce this situation we set symbol := nil and trigger a GC to make the symbol table release the weak reference to the symbol."

	| segment root string symbol |
	string := 'randomStringForSymbolThatDoesNotExist'.
	Smalltalk garbageCollect.
	self assert: [ Symbol allSymbols noneSatisfy: [ :each | each asString = string ] ].
	
	symbol := string asSymbol.
	root := Array with: symbol with: #testSymbols.
	
	symbol := nil.
	Smalltalk garbageCollect.

	segment := self createSegmentFrom: root.
	self writeToFile: segment.
	
	root := segment := nil.
	Smalltalk garbageCollect.
	
	"make sure the symbol is really gone"
	self assert: [ Symbol allSymbols noneSatisfy: [ :each | each asString = string ] ].
	
	"create a new instance of the symbol and load the segment"
	symbol := string asSymbol.
	root := self loadSegmentFromFile.
	
	self assert: root first == symbol.
	self assert: root second == #testSymbols.