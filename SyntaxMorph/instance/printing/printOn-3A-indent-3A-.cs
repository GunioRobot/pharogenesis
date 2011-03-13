printOn: strm indent: level
	| lev nodeClass parens cnt |
	"Tree walk and produce text of the code.  #ST80.  Just do it in one big ugly method."

	lev _ level.
	(nodeClass _ parseNode class) == BlockNode ifTrue: [
		owner isSyntaxMorph ifTrue: [
			owner isMethodNode ifFalse: [strm nextPut: $[.  lev _ lev+1]]].
				"normal block has []"
	nodeClass == VariableNode ifTrue: ["nil out any old association"
		parseNode key class == Association ifTrue: [
			parseNode name: (parseNode name) key: nil code: (parseNode code)]].
	(nodeClass == MessageNode or: [nodeClass == CascadeNode]) ifTrue: [
		parseNode receiver ifNotNil: [parens _ true.  strm nextPut: $( ]].
	"has a receiver"
	nodeClass == MethodTempsNode ifTrue: [strm nextPut: $|; space].
	cnt _ 0.
	submorphs do: [:sub |
		sub isSyntaxMorph ifTrue: [cnt _ cnt + 1.
			(nodeClass == CascadeNode "and: [sub isCascadePart]") ifTrue:
				[cnt > 2 ifTrue: [strm nextPutAll: '; ']].
			nodeClass == BlockArgsNode ifTrue: [strm nextPut: $:].
			sub printOn: strm indent: lev.	"<<<<### install the subnode"
			(nodeClass == BlockNode) & (sub parseNode class == BlockArgsNode) not	&
				(sub parseNode class == ReturnNode) not
					ifTrue: [strm nextPut: $.].
			(nodeClass == BlockNode) & (sub parseNode class == BlockArgsNode) not
				ifTrue: [strm crtab: lev]
				ifFalse: [self isMethodNode ifTrue: [strm crtab: lev] ifFalse: [strm space]].
			].
		(sub isKindOf: StringMorph) ifTrue: [strm nextPutAll: sub contents].
		"return indent for ifTrue: ifFalse:"].
	parens == true ifTrue: [strm nextPut: $) ].
	"has a receiver"
	nodeClass  == BlockNode ifTrue: [
		owner isSyntaxMorph ifTrue: [
			owner isMethodNode ifFalse: [strm nextPut: $] ]]].
				"normal block has []"
	nodeClass == BlockArgsNode ifTrue: [strm nextPut: $|; crtab: lev].
	nodeClass == MethodTempsNode ifTrue: [strm nextPut: $|; crtab: lev].
	nodeClass == MethodNode ifTrue: [
		strm contents last "ugh!" == $. ifTrue: [strm skip: -1]].
	"erase last period"