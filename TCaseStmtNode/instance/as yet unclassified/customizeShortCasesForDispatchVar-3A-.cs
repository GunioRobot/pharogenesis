customizeShortCasesForDispatchVar: varName
	"Make customized versions of a short bytecode methods, substituting a constant having the case index value for the given variable. This produces better code for short bytecodes such as instance variable pushes that encode the index of the instance variable in the bytecode."

	| newFirsts newLasts newCases l f case expanded |
	newFirsts _ OrderedCollection new.
	newLasts _ OrderedCollection new.
	newCases _ OrderedCollection new.
	1 to: cases size do: [ :i |
		l _ lasts at: i.
		f _ firsts at: i.
		case _ cases at: i.
		expanded _ false.
		(l - f) > 1 ifTrue: [  "case code covers multiple cases"
			case nodeCount < 60 ifTrue: [
				newFirsts addAll: (f to: l) asArray.
				newLasts addAll: (f to: l) asArray.
				newCases addAll: (self customizeCase: case forVar: varName from: f to: l).
				expanded _ true.
			].
		].
		expanded ifFalse: [
			self fixSharedCodeBlocksForCase: f in: case.
			newFirsts addLast: f.
			newLasts addLast: l.
			newCases addLast: case.
		].
	].
	firsts _ newFirsts asArray.
	lasts _ newLasts asArray.
	cases _ newCases asArray.
