browseObsoleteMethodReferences
	"Open a browser on all referenced behaviors that are obsolete"
	"Smalltalk browseObsoleteMethodReferences"
	| list |
	self deprecated: 'Use SmalltalkImage current browseObsoleteMethodReferences'.
	list _ self obsoleteMethodReferences.
	self systemNavigation  browseMessageList: list name:'Method referencing obsoletes' autoSelect: nil