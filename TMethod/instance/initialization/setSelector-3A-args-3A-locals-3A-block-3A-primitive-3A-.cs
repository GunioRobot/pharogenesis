setSelector: sel args: argList locals: localList block: aBlockNode primitive: aNumber
	"Initialize this method using the given information."

	selector _ sel.
	returnType _ 'int'. 	 "assume return type is int for now"
	args _ argList asOrderedCollection collect: [:arg | arg key].
	locals _ localList asOrderedCollection collect: [:arg | arg key].
	declarations _ Dictionary new.
	primitive _ aNumber.
	parseTree _ aBlockNode asTranslatorNode.
	labels _ OrderedCollection new.
	complete _ false.  "set to true when all possible inlining has been done"
	export _ self extractExportDirective.
	static _ self extractStaticDirective.
	self removeFinalSelfReturn.
	self recordDeclarations.
