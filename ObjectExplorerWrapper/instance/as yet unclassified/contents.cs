contents
	| answer |
	answer _ OrderedCollection new.
	"Don't show internal representation of these"
	({OrderedCollection. FloatArray. Dictionary} anySatisfy: [:class | item isKindOf: class])
		ifTrue: [
			item keysAndValuesDo: [:key :value |
				answer add: (ObjectExplorerWrapper
					with: value
					name: (key printString contractTo: 32)
					model: item)].
			^ answer].
	"Same for Sets, but must provide an index"
	(item isKindOf: Set) ifTrue: [
		item doWithIndex: [:each :index |
			answer add: (ObjectExplorerWrapper
				with: each
				name: index printString
				model: item)].
		^ answer].
	"For all others, show named vars first, then indexed vars"
	item class allInstVarNames asArray doWithIndex: [:each :index |
		answer add: (ObjectExplorerWrapper
			with: (item instVarAt: index)
			name: each
			model: item)].
	1 to: item basicSize do: [:index |
		answer add: (ObjectExplorerWrapper
			with: (item basicAt: index)
			name: index printString
			model: item)].
	^ answer