initWordingAndDocumentation
	"Initialize wording and documentation (helpMessage) for getters and setters"

	| elSym |
	elSym := self elementSymbol.
	elSym
		ifNil: [^self].

	((elSym beginsWith: 'get')
		and: [elSym size > 3])
		ifTrue: [
			self wording: (elSym allButFirst: 3) withFirstCharacterDownshifted.
			self getterSetterHelpMessage: 'get value of {1}']
		ifFalse: [
			((elSym beginsWith: 'set')
				and: [elSym size > 4])
				ifTrue: [
					self wording: (elSym allButFirst: 3) withFirstCharacterDownshifted.
					self getterSetterHelpMessage: 'set value of {1}']]