upDownArrows
	"Return an array of two up/down arrow buttons.
	It replaces the selector or arg with a new one.
	I am a number or boolean or a selector (beep:, +,-,*,//,\\, or setX: incX: decX: for any X."
	| patch sel any ok |
	any _ (self nodeClassIs: LiteralNode) and: [parseNode key isNumber].
	any _ any or: [(self nodeClassIs: VariableNode) and:
						[(#('true' 'false') includes: self decompile asString)]].
	any _ any or: [(self nodeClassIs: SelectorNode) and:
				[ok _ #(beep: + - * // \\) includes: (sel _ parseNode key).
				ok _ ok or: [(sel beginsWith: 'set') and: [(sel atWrap: 4) isUppercase]].
				ok _ ok or: [sel size > 11 and:
						[#('IncreaseBy:' 'DecreaseBy:' 'MultiplyBy:') includes: (sel last: 11)]].
				ok]].
	any _ any or: [(self nodeClassIs: SelectorNode) and:
				[ok _ #(= ~= == ~~) includes: (sel _ parseNode key).
				ok]].
	any ifFalse: [^ nil].

	patch _ {(ImageMorph new image: TileMorph upPicture)
				on: #mouseDown send: #event:arrow:upDown: to: self withValue: 1.
			(ImageMorph new image: TileMorph downPicture)
				on: #mouseDown send: #event:arrow:upDown: to: self withValue: -1}.
	^ patch