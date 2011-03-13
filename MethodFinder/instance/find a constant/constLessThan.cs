constLessThan
	| const subTest got minConst maxConst tt |
	"See if (data1 <= C) or (data1 >= C) is the answer"

	"quick test"
	((answers at: 1) class superclass == Boolean) ifFalse: [^ false].
	2 to: answers size do: [:ii | 
		((answers at: ii) class superclass == Boolean) ifFalse: [^ false]].

	minConst _ Float infinity.  maxConst _ minConst negated.
	answers withIndexDo: [:aa :ii |
		aa ifTrue: [tt _ (thisData at: ii) at: 1.
			minConst _ minConst min: tt.
			maxConst _ maxConst max: tt]].
	const _ (thisData at: 1) at: 1.
	got _ (subTest _ MethodFinder new copy: self addArg: minConst) 
				searchForOne isEmpty not.
	got ifFalse: ["try other extreme for <= >= "
		got _ (subTest _ MethodFinder new copy: self addArg: maxConst) 
				searchForOne isEmpty not]. 
	got ifFalse: [^ false]. 

	"replace data2 with const in expressions"
	subTest expressions do: [:exp |
		expressions add: (exp copyReplaceAll: 'data2' with: const printString)].
	selector addAll: subTest selectors.
	^ true