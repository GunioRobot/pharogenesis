declareInstVar: name
	" rr 3/6/2004 16:06 : adds the line to correctly compute the index. uncommented the option in 
	the caller."
	| index |
	encoder classEncoding addInstVarName: name.
	index _ encoder classEncoding instVarNames indexOf: name.
	encoder classEncoding allSuperclassesDo: [:cls | index := index + cls instVarNames size].
	^LiteralVariableNode new
		name: name index: index - 1 type: 1;
		yourself
		