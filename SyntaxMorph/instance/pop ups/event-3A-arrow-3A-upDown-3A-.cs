event: evt arrow: arrowMorph upDown: delta

	| st aList index now want instVar |
	st _ submorphs detect: [:mm | mm isKindOf: StringMorph] ifNone: [^ self].
	(self nodeClassIs: LiteralNode) ifTrue: [ "+/- 1"
		st contents: (self decompile asNumber + delta) printString.
		^ self acceptSilently.	"maybe set parseNode's key"].
	(self nodeClassIs: VariableNode) ifTrue: [ "true/false"
		st contents: (self decompile asString = 'true') not printString.
		^ self acceptSilently.	"maybe set parseNode's key"].

	(self nodeClassIs: SelectorNode) ifTrue: [
		aList _ #(+ - * / // \\ min: max:).
		index _ aList indexOf: self decompile asString.
		index  > 0 ifTrue: [
			self setBalloonText:
				(ScriptingSystem helpStringForOperator: (aList atWrap: index + delta)).
			st contents: (aList atWrap: index + delta).
			^ self acceptSilently].

		aList _ #(= ~= > >= isDivisibleBy: < <=).
		index _ aList indexOf: self decompile asString.
		index  > 0 ifTrue: [
			self setBalloonText:
				(ScriptingSystem helpStringForOperator: (aList atWrap: index + delta)).
			st contents: (aList atWrap: index + 1).
			^ self acceptSilently].

		aList _ #(== ~~).
		index _ aList indexOf: self decompile asString.
		index  > 0 ifTrue: [
			self setBalloonText:
				(ScriptingSystem helpStringForOperator: (aList atWrap: index + delta)).
			st contents: (aList atWrap: index + delta).
			^ self acceptSilently].

		'beep:' = self decompile asString ifTrue: ["replace sound arg"
			self changeSound: delta.
			^ self acceptSilently].
		].
	(self nodeClassIs: SelectorNode) ifTrue: ["kinds of assignment"
		((now _ self decompile asString) beginsWith: 'set') ifTrue:
			["a setX: 3"
			want _ 1+delta.  instVar _ (now allButFirst: 3) allButLast].
		(now endsWith: 'IncreaseBy:') ifTrue: ["a xIncreaseBy: 3 a setX: (a getX +3)."
			want _ 2+delta.  instVar _ now allButLast: 11].
		(now endsWith: 'DecreaseBy:') ifTrue: ["a xDecreaseBy: 3 a setX: (a getX -3)."
			want _ 3+delta.  instVar _ now allButLast: 11].
		(now endsWith: 'MultiplyBy:') ifTrue: ["a xMultiplyBy: 3 a setX: (a getX *3)."
			want _ 4+delta.  instVar _ now allButLast: 11].
		want ifNil: [^ self].
		instVar _ instVar asLowercase.
		want _ #(1 2 3 4) atWrap: want.
		want = 1 ifTrue: [st contents: 'set', instVar capitalized, ':'].	"setter method is present"
		want = 2 ifTrue: [st contents: instVar, 'IncreaseBy:'].
			"notUnderstood will create the method if needed"
		want = 3 ifTrue: [st contents: instVar, 'DecreaseBy:'].
			"notUnderstood will create the method if needed"
		want = 4 ifTrue: [st contents: instVar, 'MultiplyBy:'].
			"notUnderstood will create the method if needed"

		^ self acceptSilently].

