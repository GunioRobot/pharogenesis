constEquiv
	| const subTest got jj |
	"See if (data1 = C) or (data1 ~= C) is the answer"

	"quick test"
	((answers at: 1) class superclass == Boolean) ifFalse: [^ false].
	2 to: answers size do: [:ii | 
		((answers at: ii) class superclass == Boolean) ifFalse: [^ false]].

	const _ (thisData at: 1) at: 1.
	got _ (subTest _ MethodFinder new copy: self addArg: const) 
				searchForOne isEmpty not.
	got ifFalse: ["try other polarity for ~~ "
		(jj _ answers indexOf: (answers at: 1) not) > 0 ifTrue: [
		const _ (thisData at: jj) at: 1.
		got _ (subTest _ MethodFinder new copy: self addArg: const) 
				searchForOne isEmpty not]]. 
	got ifFalse: [^ false]. 

	"replace data2 with const in expressions"
	subTest expressions do: [:exp |
		expressions add: (exp copyReplaceAll: 'data2' with: const printString)].
	selector addAll: subTest selectors.
	^ true