I am a Smalltalk method / expression parser.

Rather than creating an Abstract Syntax Tree, I create a sequence of SHRanges (in my 'ranges' instance variable), which represent the tokens within the String I am parsing.

I am used by a SHTextStylerST80 to parse method source strings.
I am able to parse incomplete / incorrect methods, and so can be used to parse methods that are being edited.

My 'source' instance variable should be set to the string to be parsed.

My 'classOrMetaClass' instance var must be set to the class or metaClass for the method source so that I can correctly resolve identifiers within the source. If this is nil , I parse the source as an expression (i.e. a doIt expression).

My 'workspace' instance variable can be set to a Workspace, so that I can resolve workspace variables.

My 'environment' instance variable is the global namespace (this is initialized to Smalltalk, but can be set to a different environment).

Example 1.
	ranges := SHParserST80 new
		classOrMetaClass: Object;
		source: 'testMethod ^self';
		parse;
		ranges
		
