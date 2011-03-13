asMorphicCaseOn: parent indent: ignored
	"receiver caseOf: {[key]->[value]. ...} otherwise: [otherwise]"

	| braceNode otherwise |

	braceNode _ arguments first.
	otherwise _ arguments last.
	((arguments size = 1) or: [otherwise isJustCaseError]) ifTrue: [
		self morphFromKeywords: #caseOf: arguments: {braceNode} on: parent indent: nil.
		^parent
	].
	self morphFromKeywords: #caseOf:otherwise: arguments: arguments on: parent indent: nil.
	^parent
