drawPostscriptContext:subCanvas
	| contents |
	contents _ subCanvas contents.
	contents ifNotNil:[
		^target comment:' sub-canvas start';
			gsave;
			print:subCanvas contents;
			grestore;
			comment:'sub-canvas stop'.	
	].
